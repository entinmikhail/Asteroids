using UnityEngine;

namespace Asteroids.Abstraction
{
    public abstract class BaseBehavior : ScriptableObject
    {
        protected ILevelObjectViewUnity _viewUnity;
        protected IPlayerViewUnity _playerViewUnity;
        
        public abstract void OnUpdate(ILevelObjectView view, IPlayerView playerView, float speed);

        public void Init(ILevelObjectView view, IPlayerView playerView, params object[] additionalParams)
        {
            _viewUnity = (ILevelObjectViewUnity) view;
            _playerViewUnity = (IPlayerViewUnity) playerView;

            OnInit(additionalParams);
        }

        protected abstract void OnInit(params object[] additionalParams);

        public abstract void DiedBehaviour(ILevelModel levelModel, params object[] additionalParams);
    }
}