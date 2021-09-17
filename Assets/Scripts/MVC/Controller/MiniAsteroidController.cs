using Asteroids.Abstraction;
using Asteroids.Model;

namespace Asteroids.Controller
{
    public class MiniAsteroidController : EnemyControllerBase
    {
        private readonly  MiniAsteroid _miniAsteroid;
        
        public MiniAsteroidController(IEnemy enemy, ILevelManager levelManager) : base(enemy, levelManager)
        {
            _miniAsteroid = (MiniAsteroid) enemy;
        }

        protected override void InitBehaviour()
        {
            _behaviour.Init(_view, _playerView, _enemyInfo.MovementSpeed, _miniAsteroid.InitialPosition);
        }
        
        protected override void OnStart() { }
        protected override void OnDispose() { }
    }
}