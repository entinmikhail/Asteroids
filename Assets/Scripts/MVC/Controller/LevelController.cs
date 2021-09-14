using System.Collections.Generic;
using Asteroids.Abstraction;

namespace Asteroids.Controller
{
    public class LevelController : IController, IUpdatable
    {
        private readonly IPointModel _pointModel;

        private readonly IDictionary<IEnemy, IEnemyController> _enemies = new Dictionary<IEnemy, IEnemyController>();
        private readonly IDictionary<IShell, IShellController> _shells = new Dictionary<IShell, IShellController>();
        
        private readonly ILevelModel _levelModel;
        private readonly ILevelInfo _levelInfo;
        private readonly ILevelManager _levelManager;
        
        private readonly IList<IUpdatable> _controllersToUpdate = new List<IUpdatable>();
        private readonly IList<IUpdatable> _controllersToRemoveFromUpdate = new List<IUpdatable>();
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
            
            /*_levelModel.EnemyAdded += OnEnemyAddedToLevel;
            _levelModel.EnemyRemoved += OnEnemyRemovedFromLevel;*/
            _levelModel.ShellAdded += OnShellAddedToLevel;
            _levelModel.ShellRemoved += OnShellRemovedFromLevel;
        }

        public void Update(double deltaTime)
        {
            foreach (var updatable in _controllersToUpdate)
            {
                updatable.Update(deltaTime);
            }

            if (_controllersToRemoveFromUpdate.Count != 0)
            {
                foreach (var controller in _controllersToRemoveFromUpdate)
                {
                    _controllersToUpdate.Remove(controller);
                }
                _controllersToRemoveFromUpdate.Clear();
            }
        }
        
        private void OnEnemyAddedToLevel(IEnemy enemy)
        {
            AddEnemyController(enemy);
        }

        private void OnShellAddedToLevel(IShell shell)
        {
            AddShellController(shell);
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

        private void AddShellController(IShell shell)
        {
            if (_shells.ContainsKey(shell)) return;  
            var controller = ShellControllerFactory.Build<IShellController>(shell.GetInfo().Type, shell, _levelManager);
            controller.Start();

            if (controller is IUpdatable updatable)
            {
                _controllersToUpdate.Add(updatable);
            }

            _shells.Add(shell, controller);
        }
        
        private void OnEnemyRemovedFromLevel(IEnemy enemy)
        {
            _pointModel.ProceedEnemyDied(enemy);
            var controller = _enemies[enemy];
            
            if (controller is IUpdatable updatable)
            {
                _controllersToRemoveFromUpdate.Add(updatable);
            } 
            
            controller.CurrentBehavior.DiedBehaviour(_levelModel, enemy.GetTransform().position); 
            controller.Dispose();       
            
            _enemies.Remove(enemy);
        }

        private void OnShellRemovedFromLevel(IShell shell)
        {
            var controller = _shells[shell];

            if (controller is IUpdatable updatable)
            {
                _controllersToRemoveFromUpdate.Add(updatable);
            }
            
            controller.Dispose();       
            
            _shells.Remove(shell);
        }

        public void Dispose()
        {
            if (!_inited) return;
            _inited = false;

            _levelModel.EnemyAdded -= OnEnemyAddedToLevel;
            _levelModel.EnemyRemoved -= OnEnemyRemovedFromLevel;
            
            _levelModel.ShellAdded -= OnShellAddedToLevel;
            _levelModel.ShellRemoved -= OnShellRemovedFromLevel;
            
            foreach (var controller in _enemies.Values)
            {
                controller.Dispose();
            }
            _enemies.Clear();
            _levelModel.ClearLevel();
        }
    }
}