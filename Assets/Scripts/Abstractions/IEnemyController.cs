using Asteroids.Abstraction;

namespace Asteroids.Controller
{
    public interface IEnemyController : IController
    {
        BaseBehavior CurrentBehavior { get; }
    }
}