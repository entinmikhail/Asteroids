using Asteroids.Abstraction;
using UnityEngine;

namespace Asteroids.Core
{
    public class LevelManager : ILevelManager
    {
        private ILevelModel _currentLevel;
        private readonly IPlayerView _playerView;

        public LevelManager(IPlayerView playerView)
        {
            _playerView = playerView;
        }

        public IPlayerView GetPlayerView() => _playerView;
        
        public void SetLevel(ILevelModel levelModel)
        {
            _currentLevel = levelModel;
        }

        public ILevelModel GetCurrentLevel() => _currentLevel;

        public T GetObjectView<T>(string id, Vector3 position)where T : ILevelObjectView
        {
            var levelInfo = _currentLevel.GetInfo();

            var go = Object.Instantiate(levelInfo.GetLevelObjectPrefab(id), position, Quaternion.identity);
            if (!go.TryGetComponent(out T result))
            {
                Debug.LogAssertion($"GameObjet {go.name} doesnt have {typeof(T)} component");
            }

            return result;
        }
    }
}