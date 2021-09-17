using Asteroids.Abstraction;

namespace Asteroids.ScriptableObjects
{       
    public abstract class BaseBehaviorUnity2D : BaseBehavior
    {
        protected ILevelObjectViewUnity2D _viewUnity;
        protected IPlayerViewUnity2D _playerViewUnity;
        public override void Init(ILevelObjectView view, IPlayerView playerView, params object[] additionalParams)
        {
            {
                _viewUnity = (ILevelObjectViewUnity2D) view;
                _playerViewUnity = (IPlayerViewUnity2D) playerView;

                OnInit(additionalParams);
            }
        }
        public override void SetPlayerView(IPlayerView playerView)
        {
            _playerViewUnity = (IPlayerViewUnity2D) playerView;
        }
    }
    
    public abstract class BaseBehaviorUnity3D : BaseBehavior
    {
        protected ILevelObjectViewUnity3D _viewUnity;
        protected IPlayerViewUnity3D _playerViewUnity;
        public override void Init(ILevelObjectView view, IPlayerView playerView, params object[] additionalParams)
        {
            {
                _viewUnity = (ILevelObjectViewUnity3D) view;
                _playerViewUnity = (IPlayerViewUnity3D) playerView;

                OnInit(additionalParams);
            }
        }
        public override void SetPlayerView(IPlayerView playerView)
        {
            _playerViewUnity = (IPlayerViewUnity3D) playerView;
        }
    }
}