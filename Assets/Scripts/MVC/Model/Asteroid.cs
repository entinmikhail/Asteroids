using Asteroids.Abstraction;

namespace Asteroids.Model
{
    public class Asteroid : EnemyBase
    {
        public Asteroid(IEnemyInfo enemyInfo) : base(enemyInfo)
        {
        }
    }
}