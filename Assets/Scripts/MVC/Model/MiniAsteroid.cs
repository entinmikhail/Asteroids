using Asteroids.Abstraction;
using Utils;

namespace Asteroids.Model
{
    public class MiniAsteroid : EnemyBase, IMiniAsteroid
    {
        public CustomVector3 InitialPosition { get; private set; }
        public MiniAsteroid(IEnemyInfo enemyInfo, CustomVector3 initialPosition) : base(enemyInfo)
        {
            InitialPosition = initialPosition;
        }
    }
}