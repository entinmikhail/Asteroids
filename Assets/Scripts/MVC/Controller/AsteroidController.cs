using Asteroids.Abstraction;
using UnityEngine;
using Utils;

namespace Asteroids.Controller
{
    public class AsteroidController : EnemyControllerBase
    {
        public AsteroidController(IEnemy enemy, ILevelManager levelManager) : base(enemy, levelManager)
        {
        }

        protected override CustomVector3 GetStartPosition()
        {
            var levelInfo = _levelManager.GetCurrentLevel().GetInfo();
            
            return new Vector3(Random.Range(levelInfo.LevelBounds.min.x, levelInfo.LevelBounds.max.x),
                Random.Range(levelInfo.LevelBounds.min.y, levelInfo.LevelBounds.max.y),
                Random.Range(levelInfo.LevelBounds.min.z, levelInfo.LevelBounds.max.z));
        }

        protected override void OnStart()
        {
            _behaviour.Init(_view, _playerView, _enemyInfo.MovementSpeed);
        }
        
        protected override void OnDispose()
        {
        }
    }
}