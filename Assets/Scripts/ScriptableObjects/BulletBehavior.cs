using Asteroids.Abstraction;
using UnityEngine;

namespace Asteroids.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Gameplay/ObjectsBehavior/BulletBehavior", fileName = "BulletBehavior")]
    public class BulletBehavior : BaseBehaviorUnity
    
    {
        public override void OnUpdate (ILevelObjectView view, IPlayerView playerView, float speed)
        {
            
        }
        
        protected override void OnInit(params object[] additionalParams)
        {
            var shellInfo = (IShellInfo) additionalParams[0];
            _viewUnity.Rigidbody2D.AddForce(_playerViewUnity.SpawnPoint.transform.up * shellInfo.MovementSpeed, ForceMode2D.Impulse);
        }

        public override void DiedBehaviour(ILevelModel levelModel, params object[] additionalParams)
        {

        }
    }
}
