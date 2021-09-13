using Asteroids.Abstraction;
using Asteroids.Model;
using Utils;

namespace Asteroids.Controller
{
    public abstract class EnemyControllerBase : IEnemyController, IUpdatable
    {
        protected ILevelObjectView _view;
        protected BaseEnemyBehavior _enemyBehaviour;

        protected readonly IEnemyInfo _enemyInfo;
        protected readonly ILevelManager _levelManager;

        protected IPlayerView _playerView;
        
        private IResourceModel _healthModel;
        private readonly IEnemy _enemy;
        
        private bool _inited;

        protected EnemyControllerBase(IEnemy enemy, ILevelManager levelManager)
        {
            _enemy = enemy;
            _enemyInfo = enemy.GetInfo();
            _levelManager = levelManager;
        }
        
        public void Start()
        {
            if (_inited) return;
            _inited = true;
            var position = GetStartPosition();
            
            _view = _levelManager.CreateObjectView<ILevelObjectView>(_enemy, position);
            _enemyBehaviour = _enemyInfo.EnemyBehavior;
            _healthModel = _enemy.GetResource(ProjConstants.HealthId);
            _playerView = _levelManager.GetView<IPlayerView>(_levelManager.GetCurrentLevel().CurrentPlayer);
            
            _enemy.ChangeTransform(_view.Transform);
            
            OnStart();
            
            _view.OnLevelObjectContact += OnCollision;
            _enemy.HealthEnded += OnEnemyDied;
        }

        protected abstract CustomVector3 GetStartPosition();
        protected abstract void OnDispose();
        protected abstract void OnStart();
        
        public void Update(double deltaTime)
        {
            if(!_inited) return;
            
            _enemyBehaviour.OnUpdate(_view, _playerView, _enemyInfo.MovementSpeed);
            _enemy.ChangeTransform(_view.Transform);
        }
        
        private void OnCollision(ILevelObjectView selfObject, ILevelObjectView contactObject)
        {
            if (contactObject.Transform.gameObject.CompareTag("Shell")) // 
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

            _levelManager.DestroyView(_enemy, _view);
        }
    }
}