using Asteroids.Abstraction;
using Asteroids.Model;

namespace Asteroids.Controller
{
    public abstract class ShellControllerBase : IShellController, IUpdatable
    {
        protected ILevelObjectView _view;
        protected readonly IShellInfo _shellInfo;

        private readonly ILevelManager _levelManager;
        private readonly IShell _shell;
        private readonly IGameModel _gameModel;

        protected BaseBehavior _shellBehavior;
        protected IPlayerView _playerView;
        
        private bool _inited;
        
        protected ShellControllerBase(IShell shell, ILevelManager levelManager)
        {
            _shell = shell;
            _shellInfo = shell.GetInfo();
            _levelManager = levelManager;
            _gameModel = _levelManager.GetCurrentLevel().GameModel;
            
        }

        public void Start()
        {
            if (_inited) return;
            _inited = true;

            _shellBehavior = _levelManager.CreateBehavior(_gameModel.CurViewMode, _shell);
            _playerView = _levelManager.GetOrCreateView<IPlayerView>(_levelManager.GetCurrentLevel().CurrentPlayer);
            _shellBehavior.SetPlayerView(_playerView);
            
            _view = _levelManager.CreateObjectView<ILevelObjectView>(_shell);

            _view.OnLevelObjectContact += OnCollision;
            _shell.ShellDestroyed += OnShellDestroyed;
            
            InitBehaviour();
        }

        private void OnCollision(ILevelObjectView selfObject, ILevelObjectView contactObject)
        {
            if (_shellInfo.Destroyable && contactObject.Tag == ProjConstants.Enemy)
            {
                _shell.DestroyShell();
            }
        }
        
        protected abstract void InitBehaviour();

        public void ResetView()
        {
            _view.OnLevelObjectContact -= OnCollision;
            _view = _levelManager.GetOrCreateView<ILevelObjectView>(_shell);
            
            _levelManager.DestroyBehaviour(_shellBehavior);
            _shellBehavior = _levelManager.CreateBehavior(_gameModel.CurViewMode, _shell);
            _playerView = _levelManager.GetOrCreateView<IPlayerView>(_levelManager.GetCurrentLevel().CurrentPlayer);

            InitBehaviour();
            _view.OnLevelObjectContact += OnCollision;
        }

        public void Update(double deltaTime)
        {
            if (!_inited) return;
            
            _shell.GetLifeTimeModel().SetLifeTime(deltaTime);
            _shell.SetTransform(_view.Transform);
            _shellBehavior.OnUpdate(_view, _playerView, _shellInfo.MovementSpeed);
        }

        private void OnShellDestroyed(IShell obj)
        {
            Dispose();
        }
        
        public void Dispose()
        {
            if (!_inited) return;
            _inited = false;
            
            _view.OnLevelObjectContact -= OnCollision;
            _shell.ShellDestroyed -= OnShellDestroyed;
            
            _levelManager.DestroyView(_shell); 
            _levelManager.DestroyBehaviour(_shellBehavior); 
        }
    }
}