using Asteroids.Abstraction;

namespace Asteroids.Controller
{
    public interface IEnemyController : IController
    {
        ILevelObjectView View { get; }
    }
}