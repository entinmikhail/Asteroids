using Asteroids.Abstraction;
using UnityEngine;

namespace Asteroids.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Gameplay/ObjectsBehavior/BulletBehavior", fileName = "BulletBehavior")]
    public class LaserBehavior : BaseShellBehavior
    
    {
        public override void OnUpdate (ILevelObjectView view, IPlayerView playerView, float speed)
        {
            
        }

        public override void Init(ILevelObjectView view, IPlayerView playerView, params object[] additionalParams)
        {
            
        }

        public override void DiedBehaviour(ILevelModel levelModel, params object[] additionalParams)
        {

        }
    }
}