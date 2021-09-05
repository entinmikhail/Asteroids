using System;
using System.Collections.Generic;
using Asteroids.Abstraction;

namespace Asteroids.Model
{
    public sealed class LevelModel : ILevelModel
    {
        public event Action<IEnemy> EnemyAdded;
        public event Action<IEnemy> EnemyRemoved;

        public IList<IEnemy> CurrentEnemies => _enemies;

        private readonly ILevelInfo _levelInfo;
        private readonly IList<IEnemy> _enemies = new List<IEnemy>();
        
        public LevelModel(ILevelInfo levelInfo)
        {
            _levelInfo = levelInfo;
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
        
        private void AddEnemy(IEnemy enemy)
        {
            enemy.HealthEnded += OnEnemyDied;
            _enemies.Add(enemy);

            EnemyAdded?.Invoke(enemy);
        }

        private void OnEnemyDied(IEnemy enemy)
        {
            RemoveEnemy(enemy);
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