using Asteroids.Abstraction;
using UnityEngine;

namespace Asteroids.View
{
    public class PlayerView : LevelObjectView, IPlayerView
    {
        public Transform SpawnPoint => _spawnPoint;
        [SerializeField] private Transform _spawnPoint;
    }
}

