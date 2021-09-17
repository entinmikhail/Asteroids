using Asteroids.Abstraction;
using Asteroids.Model;

namespace Asteroids.Controller
{
    public abstract class EnemyControllerBase : IEnemyController, IUpdatable
    {
        public BaseBehavior CurrentBehavior => _behaviour;
        
        protected ILevelObjectView _view;
        protected BaseBehavior _behaviour;

        protected readonly IEnemyInfo _enemyInfo;
        protected readonly ILevelManager _levelManager;

        private readonly IGameModel _gameModel;
        protected IPlayerView _playerView;
        
        private IResourceModel _healthModel;
        private readonly IEnemy _enemy;
        
        private bool _inited;

        protected EnemyControllerBase(IEnemy enemy, ILevelManager levelManager)
        {
            _enemy = enemy;
            _enemyInfo = enemy.GetInfo();
            _levelManager = levelManager;
            _gameModel = _levelManager.GetCurrentLevel().GameModel;
        }
        
        public void Start()
        {
            if (_inited) return;
            _inited = true;
            
            _behaviour = _levelManager.CreateBehavior(_gameModel.CurViewMode, _enemy);
            _view = _levelManager.CreateObjectView<ILevelObjectView>(_enemy);
            
            _healthModel = _enemy.GetResource(ProjConstants.HealthId);
            _playerView = _levelManager.GetOrCreateView<IPlayerView>(_levelManager.GetCurrentLevel().CurrentPlayer);
            
            _enemy.SetTransform(_view.Transform);
            
            InitBehaviour();
            OnStart();
            
            _view.OnLevelObjectContact += OnCollision;
            _enemy.HealthEnded += OnEnemyDied;
        }

        public void ResetView()
        {
            _levelManager.DestroyBehaviour(_behaviour);
            _view = _levelManager.GetOrCreateView<ILevelObjectView>(_enemy);
            
            _behaviour = _levelManager.CreateBehavior(_gameModel.CurViewMode, _enemy);
            _playerView = _levelManager.GetOrCreateView<IPlayerView>(_levelManager.GetCurrentLevel().CurrentPlayer);
            InitBehaviour();
        }
        
        protected abstract void OnDispose();
        protected abstract void OnStart();
        protected abstract void InitBehaviour();
        
        public void Update(double deltaTime)
        {
            if(!_inited) return;
            
            _behaviour.OnUpdate(_view, _playerView, _enemyInfo.MovementSpeed);
            _enemy.SetTransform(_view.Transform);
        }
        
        private void OnCollision(ILevelObjectView selfObject, ILevelObjectView contactObject)
        {
            if (contactObject.Tag == ProjConstants.Shell) 
            {
                var shellInfo = _levelManager.GetCurrentLevel().GetInfo().GetWeaponInfo(contactObject.LevelObjectType);
                
                _healthModel.ChangeResource(-shellInfo.DamageValue);
            }
        }

        private void OnEnemyDied(IModel<IEnemyInfo> obj)
        {
            Dispose();
        }
        
        public void Dispose()
        {
            if (!_inited) return;
            _inited = false;

            OnDispose();
            _view.OnLevelObjectContact -= OnCollision;
            _enemy.HealthEnded += OnEnemyDied;

            _levelManager.DestroyView(_enemy);
            _levelManager.DestroyBehaviour(_behaviour);
        }
    }
}