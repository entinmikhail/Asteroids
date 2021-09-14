using Asteroids.Abstraction;
using Asteroids.Model;

namespace Asteroids.Controller
{
    public abstract class ShellControllerBase : IShellController, IUpdatable
    {
        protected ILevelObjectView _view;
        
        private ILevelManager _levelManager;
        protected BaseBehavior _shellBehavior;
        private ShellBaseModel _shellBaseModel;
        protected readonly IShellInfo _shellInfo;
        protected IPlayerView _playerView;
        private readonly IShell _shell;
        private IGameModel _gameModel;

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

            _shellBehavior = _shellInfo.CreateShellBehavior(_gameModel.CurViewMode);
            _playerView = _levelManager.GetOrCreateView<IPlayerView>(_levelManager.GetCurrentLevel().CurrentPlayer);
            _view = _levelManager.CreateObjectView<ILevelObjectView>(_shell, _playerView.CustomSpawnPoint.position);

            _gameModel.ViewModeChanged += OnViewChange;
            _view.OnLevelObjectContact += OnCollision;
            _shell.ShellDestroyed += OnShellDestroyed;
            
            InitBehaviour();
        }

        private void OnViewChange(ViewMode viewMode)
        {
            _view = _levelManager.ChangeView<ILevelObjectView>(_shell);
            
            _shellBehavior = _shellInfo.CreateShellBehavior(viewMode); 
            
            _shellBehavior.Init(_view, _playerView, _shellInfo);
        }
        
        private void OnCollision(ILevelObjectView selfObject, ILevelObjectView contactObject)
        {
            if (_shellInfo.Destroyable && contactObject.Tag == ProjConstants.Enemy)
            {
                _shell.DestroyShell();
            }
        }
        
        protected abstract void InitBehaviour();

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
            
            _gameModel.ViewModeChanged -= OnViewChange;
            _view.OnLevelObjectContact -= OnCollision;
            _shell.ShellDestroyed -= OnShellDestroyed;
            
            _levelManager.DestroyView(_shell); 
            _levelManager.DestroyBehaviour(_shellBehavior); 
        }
    }
}