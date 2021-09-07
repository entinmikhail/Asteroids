
using System;
using Abstractions;

namespace Asteroids.Abstraction
{
    public interface IEnemy : ITransformModel
    {
        event Action<IEnemy> HealthEnded;
        IEnemyInfo GetInfo();
        IResourceModel GetResource(int id);
        
    }
}