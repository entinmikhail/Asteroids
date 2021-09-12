
namespace Asteroids.Abstraction
{
    public interface IPlayer : IModel
    {
        IPlayerInfo GetInfo();
    }
}