
using System;
using Abstractions;

namespace Asteroids.Abstraction
{
    public interface IEnemy : IModel
    {
        IEnemyInfo GetInfo();
    }

    public interface IModel : ITransformModel  
    {
        event Action<IModel> HealthEnded;
        IResourceModel GetResource(int id);
    }
}