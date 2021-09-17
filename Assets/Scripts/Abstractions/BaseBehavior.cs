using UnityEngine;
using Utils;

namespace Asteroids.Abstraction
{
    public abstract class BaseBehavior : ScriptableObject, IBaseBehavior
    {
        protected CustomTransform _customTransform;
        
        public abstract void OnUpdate(ILevelObjectView view, IPlayerView playerView, float speed);

        public abstract void Init(ILevelObjectView view, IPlayerView playerView, params object[] additionalParams);
        
        protected abstract void OnInit(params object[] additionalParams);

        public abstract void DiedBehaviour(ILevelModel levelModel, params object[] additionalParams);

        public abstract Vector3 GetStartPosition(ILevelManager levelManager, IModel<IModelInfo> enemy);

        public abstract void SetPlayerView(IPlayerView playerView);
    }
}