using System.Collections.Generic;
using Asteroids.Abstraction;
using NotImplementedException = System.NotImplementedException;

namespace Asteroids.Controller
{
    public class LevelController : IController, IUpdatable
    {
        private readonly IPointModel _pointModel;

        private readonly IDictionary<IEnemy, IEnemyController> _enemies = new Dictionary<IEnemy, IEnemyController>();
        
        private readonly ILevelModel _levelModel;
        private readonly ILevelInfo _levelInfo;
        private readonly ILevelManager _levelManager;
        
        private readonly IList<IUpdatable> _controllersToUpdate = new List<IUpdatable>();
        private bool _inited;

        public LevelController(IPointModel pointModel, ILevelManager levelManager)
        {
            _levelModel = levelManager.GetCurrentLevel();
            _pointModel = pointModel;
            _levelManager = levelManager;
        }
        
        public void Start()
        {
            if (_inited) return;
            _inited = true;
            
            _levelModel.StartLevel();
            
            foreach (var enemy in _levelModel.CurrentEnemies)
            {
                AddEnemyController(enemy);
            }
            
            _levelModel.EnemyAdded += OnEnemyAddedToLevel;
            _levelModel.EnemyRemoved += OnEnemyRemovedFromLevel;
        }

        public void Update(double deltaTime)
        {
            foreach (var updatable in _controllersToUpdate)
            {
                updatable.Update(deltaTime);
            }    
        }
        
        private void OnEnemyAddedToLevel(IEnemy enemy)
        {
            AddEnemyController(enemy);
        }

        private void AddEnemyController(IEnemy enemy)
        {
            var controller = ControllerFactory.Build<IEnemyController>(enemy.GetInfo().Type, enemy, _levelManager);
            controller.Start();

            if (controller is IUpdatable updatable)
            {
                _controllersToUpdate.Add(updatable);
            }

            _enemies.Add(enemy, controller);
        }

        private void OnEnemyRemovedFromLevel(IEnemy enemy)
        {
            _pointModel.ProceedEnemyDied(enemy);
            var controller = _enemies[enemy];
            
            if (controller is IUpdatable updatable)
            {
                _controllersToUpdate.Remove(updatable);
            } 
            
            enemy.GetInfo().EnemyBehavior.DiedBehaviour(_levelModel, _enemies[enemy].View.Transform.position);
            controller.Dispose();       
            
            _enemies.Remove(enemy);
        }

        public void Dispose()
        {
            if (!_inited) return;
            _inited = false;

            _levelModel.EnemyAdded -= OnEnemyAddedToLevel;
            _levelModel.EnemyRemoved -= OnEnemyRemovedFromLevel;
            
            foreach (var controller in _enemies.Values)
            {
                controller.Dispose();
            }
            _enemies.Clear();
            _levelModel.ClearLevel();
        }
    }
}