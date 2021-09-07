using Asteroids.Abstraction;
using Asteroids.Model;
using Utils;


namespace Asteroids.Controller
{
    public class MiniAsteroidController : EnemyControllerBase
    {
        private readonly  MiniAsteroid _miniAsteroid;
        
        public MiniAsteroidController(IEnemy enemy, ILevelManager levelManager) : base(enemy, levelManager)
        {
            _miniAsteroid = (MiniAsteroid) enemy;
        }

        protected override CustomVector3 GetStartPosition()
        {
            return _miniAsteroid.InitialPosition;
        }

        protected override void InitBehaviour()
        {
            _enemyBehaviour.Init(View, _playerView, _enemyInfo.MovementSpeed, _miniAsteroid.InitialPosition);
        }
    }
}