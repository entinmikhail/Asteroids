using Asteroids.Abstraction;
using Asteroids.ScriptableObjects;
using UnityEngine;
using Utils;

namespace Asteroids.Controller
{
    public class UfoEnemyController : EnemyControllerBase
    {
        private UfoBehavior _ufoBehavior;
        public UfoEnemyController(IEnemy enemy, ILevelManager levelManager) : base(enemy, levelManager)
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
            _ufoBehavior = (UfoBehavior) _behaviour;
            _levelManager.GetCurrentLevel().CurrentPlayer.HealthEnded += OnPlayerDead;
            _ufoBehavior.Init(_view, _playerView);
        }

        private void OnPlayerDead(IModel<IPlayerInfo> player)
        {
            _ufoBehavior.Stop();
        }

        protected override void OnDispose()
        {
            _levelManager.GetCurrentLevel().CurrentPlayer.HealthEnded -= OnPlayerDead;
        }
    }
}