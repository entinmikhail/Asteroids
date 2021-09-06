namespace Asteroids.Abstraction
{
    public interface IShellController : IController
    {
        ILevelObjectView View { get; }
    }
}