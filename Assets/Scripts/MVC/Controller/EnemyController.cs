using Asteroids.Abstraction;

namespace Asteroids.Controller
{
    public class EnemyController : EnemyControllerBase
    {
        public EnemyController(IEnemy enemy, ILevelManager levelManager) : base(enemy, levelManager)
        {
        }

        protected override void InitBehaviour()
        {
            _enemyBehaviour.Init(View, _playerView, _enemyInfo.MovementSpeed);
        }
    }
}