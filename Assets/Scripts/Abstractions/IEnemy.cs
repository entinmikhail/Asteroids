
using System;

namespace Asteroids.Abstraction
{
    public interface IEnemy
    {
        event Action<IEnemy> HealthEnded;
        IEnemyInfo GetInfo();
        IResourceModel GetResource(int id);
    }
}