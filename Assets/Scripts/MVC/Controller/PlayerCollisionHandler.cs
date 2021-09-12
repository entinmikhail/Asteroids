using System;
using Asteroids.View;
using UnityEngine;

namespace Asteroids.Controller
{
    public class PlayerCollisionHandler : IDisposable
    {
        private PlayerView _playerView;

        public event Action<string> OnGameObjectContact;
        public PlayerCollisionHandler(PlayerView playerView)
        {
            _playerView = playerView;
        }

        public void Init()
        {
            _playerView.OnGameObjectContact += OnCollision;
        }
        private void OnCollision(GameObject obj)
        {
            OnGameObjectContact?.Invoke(obj.tag); 
        }

        public void Dispose()
        {
            _playerView.OnGameObjectContact -= OnCollision;
        }
    }
}