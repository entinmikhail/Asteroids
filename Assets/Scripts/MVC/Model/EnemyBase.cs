
using Asteroids.Abstraction;

namespace Asteroids.Model
{
    public abstract class EnemyBase : ModelBase<IEnemyInfo>, IEnemy
    {
        protected EnemyBase(IEnemyInfo info) : base(info)
        {
        }

        public override IEnemyInfo GetInfo()
        {
            return _info;
        }
        
    }
}