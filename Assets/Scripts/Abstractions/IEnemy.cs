
using System;
using Abstractions;

namespace Asteroids.Abstraction
{
    public interface IEnemy : IModel<IEnemyInfo>
    {

    }

    public interface IModel<out T> : ITransformModel where T : IModelInfo
    {
        T GetInfo();
        event Action<IModel<T>> HealthEnded;
        IResourceModel GetResource(int id);
    }
}