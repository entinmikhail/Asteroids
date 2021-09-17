using Abstractions;
using Asteroids.Abstraction;
using UnityEngine;
using Utils;

namespace Asteroids.Controller
{
    public class UfoEnemyController : EnemyControllerBase
    {
        private IUfoBehaviour _ufoBehavior;
        public UfoEnemyController(IEnemy enemy, ILevelManager levelManager) : base(enemy, levelManager)
        {
        }
        
        protected override void OnStart()
        {
            _levelManager.GetCurrentLevel().CurrentPlayer.HealthEnded += OnPlayerDead;
        }

        protected override void InitBehaviour()
        {
            _ufoBehavior = (IUfoBehaviour) _behaviour;
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