using UnityEngine;

namespace Asteroids.Abstraction
{
    public interface IPlayerView: ILevelObjectView
    {
    Transform SpawnPoint { get; }
    }
}