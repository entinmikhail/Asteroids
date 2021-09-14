using Asteroids.Abstraction;
using UnityEngine;
using Utils;

namespace Asteroids.View
{
    public class PlayerView : LevelObjectView, IPlayerView, IPlayerViewUnity2D
    {
        public CustomTransform CustomSpawnPoint => _spawnPoint;
        public Transform SpawnPoint => _spawnPoint;
        [SerializeField] private Transform _spawnPoint;
    }
}

