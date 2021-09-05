using UnityEngine;

namespace Asteroids.Abstraction
{
    public abstract class BaseEnemyMoveBehavior : ScriptableObject
    {
        public abstract void OnUpdate(ILevelObjectView view, IPlayerView playerView, float speed);
        public abstract void Init(ILevelObjectView view, IPlayerView playerView, float speed);
    }
}