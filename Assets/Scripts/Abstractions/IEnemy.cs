
using System;
using Abstractions;

namespace Asteroids.Abstraction
{
    public interface IEnemy : IModel<IEnemyInfo>
    {

    }

    public interface IModel<out TInfo> : ITransformModel where TInfo : IModelInfo
    {
        TInfo GetInfo();
        event Action<IModel<TInfo>> HealthEnded;
        IResourceModel GetResource(int id);
    }
}