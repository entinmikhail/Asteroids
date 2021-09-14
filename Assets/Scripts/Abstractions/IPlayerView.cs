
using Utils;

namespace Asteroids.Abstraction
{
    public interface IPlayerView : ILevelObjectView
    {
        CustomTransform CustomSpawnPoint { get; }
    }
}