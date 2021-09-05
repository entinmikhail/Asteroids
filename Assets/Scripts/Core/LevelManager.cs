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

        public T GetObjectView<T>(string id) where T : ILevelObjectView
        {
            var levelInfo = _currentLevel.GetInfo();
            var position = new Vector3(Random.Range(levelInfo.LevelBounds.min.x, levelInfo.LevelBounds.max.x),
                Random.Range(levelInfo.LevelBounds.min.y, levelInfo.LevelBounds.max.y),
                Random.Range(levelInfo.LevelBounds.min.z, levelInfo.LevelBounds.max.z));
            
            var go = Object.Instantiate(levelInfo.GetLevelObjectPrefab(id), position, Quaternion.identity);
            if (!go.TryGetComponent(out T result))
            {
                Debug.LogAssertion($"GameObjet {go.name} doesnt have {typeof(T)} component");
            }

            return result;
        }
    }
}