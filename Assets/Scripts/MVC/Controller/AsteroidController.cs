using Asteroids.Abstraction;

namespace Asteroids.Controller
{
    public class AsteroidController : EnemyControllerBase
    {
        public AsteroidController(IEnemy enemy, ILevelManager levelManager) : base(enemy, levelManager)
        {
        }
        protected override void InitBehaviour()
        {
            _behaviour.Init(_view, _playerView, _enemyInfo.MovementSpeed);
        }
        
        protected override void OnStart() { }
        protected override void OnDispose() { }
    }
}