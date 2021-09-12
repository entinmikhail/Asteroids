using System;
using System.Collections.Generic;
using Asteroids.Abstraction;

namespace Asteroids.Model
{
    public sealed class LevelModel : ILevelModel
    {
        public event Action<IEnemy> EnemyAdded;
        public event Action<IEnemy> EnemyRemoved;
        public event Action<IShell> ShellAdded;
        public event Action<IShell> ShellRemoved;

        public IList<IEnemy> CurrentEnemies => _enemies;
        public IPlayer CurrentPlayer { get; }

        public IList<IShell> CurrentShells => _shells;
        
        private readonly ILevelInfo _levelInfo;
        private readonly IList<IEnemy> _enemies = new List<IEnemy>();
        private readonly IList<IShell> _shells = new List<IShell>();

        public LevelModel(ILevelInfo levelInfo, IPlayer player)
        {
            _levelInfo = levelInfo;
            CurrentPlayer = player;
        }
        
        public ILevelInfo GetInfo() => _levelInfo;

        public void StartLevel()
        {
            for (int i = 0; i < _levelInfo.AsteroidsOnStart; i++)
            {
                var asteroid = new Asteroid(_levelInfo.GetEnemyInfo("Asteroid"));
                AddEnemy(asteroid);
            }
            
            for (int i = 0; i < _levelInfo.UfosOnStart; i++)
            {
                var ufo = new UFO(_levelInfo.GetEnemyInfo("UFO"));
                AddEnemy(ufo);
            }
        }
        
        public void SpawnTypedEnemy(params object[] buildParams)
        {
            var info = (IEnemyInfo) buildParams[0];
            var enemy = ModelFactory.Build<IEnemy>(info.Type, buildParams);
            AddEnemy(enemy);
        }

        public void SpawnTypedShell(params object[] buildParams)
        {
            var info = (IShellInfo) buildParams[0];
            var shell = ShellModelFactory.Build<IShell>(info.Type, buildParams);
            AddShell(shell);
        }

        private void AddShell(IShell shell)
        {
            _shells.Add(shell);
            shell.ShellDestroyed += RemoveShell;
            
            ShellAdded?.Invoke(shell);
        }
        
        private void RemoveShell(IShell shell)
        {
            _shells.Remove(shell);
            shell.ShellDestroyed -= RemoveShell;

            ShellRemoved?.Invoke(shell);
        }
        
        private void AddEnemy(IEnemy enemy)
        {
            enemy.HealthEnded += OnEnemyDied;
            _enemies.Add(enemy);

            EnemyAdded?.Invoke(enemy);
        }

        private void OnEnemyDied(IModel enemy)
        {
            RemoveEnemy((IEnemy)enemy);
        }

        private void RemoveEnemy(IEnemy enemy)
        {
            enemy.HealthEnded -= OnEnemyDied;
            _enemies.Remove(enemy);

            EnemyRemoved?.Invoke(enemy);
        }

        public void ClearLevel()
        {
            _enemies.Clear();
        }
    }
}