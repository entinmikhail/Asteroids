﻿using UnityEngine;

namespace Asteroids.Abstraction
{
    public abstract class BaseBehavior : ScriptableObject
    {
        public abstract void OnUpdate(ILevelObjectView view, IPlayerView playerView, float speed);

        public abstract void Init(ILevelObjectView view, IPlayerView playerView, params object[] additionalParams);
        
        protected abstract void OnInit(params object[] additionalParams);

        public abstract void DiedBehaviour(ILevelModel levelModel, params object[] additionalParams);
    }
}