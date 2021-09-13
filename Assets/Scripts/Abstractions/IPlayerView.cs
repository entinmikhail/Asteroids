using UnityEngine;
using Utils;

namespace Asteroids.Abstraction
{
    public interface IPlayerView : ILevelObjectView
    {
         Transform SpawnPoint { get; }
         CustomTransform CustomSpawnPoint { get; }
    }
}