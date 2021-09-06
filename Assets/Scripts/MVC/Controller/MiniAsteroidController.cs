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
            _enemyBehaviour.Init(View, _playerView, _enemyInfo.MovementSpeed, _miniAsteroid.InitialPosition);
        }
    }
}