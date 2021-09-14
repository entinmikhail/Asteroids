using Asteroids.Abstraction;
using UnityEngine;
using Utils;

namespace Asteroids.View
{
    public class PlayerView3D : LevelObjectView3D, IPlayerView, IPlayerViewUnity3D
    {
        public CustomTransform CustomSpawnPoint => _spawnPoint;
        public Transform SpawnPoint => _spawnPoint;
        [SerializeField] private Transform _spawnPoint;

    }
}