using Asteroids.Abstraction;
using UnityEngine;

namespace Asteroids.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Gameplay/ObjectsBehavior/BulletBehavior", fileName = "BulletBehavior")]
    public class BulletBehavior : BaseShellBehavior
    
    {
        public override void OnUpdate (ILevelObjectView view, IPlayerView playerView, float speed)
        {
            
        }

        public override void Init(ILevelObjectView view, IPlayerView playerView, params object[] additionalParams)
        {
           
            var shellInfo = (IShellInfo) additionalParams[0];
            view.Rigidbody2D.AddForce(playerView.SpawnPoint.transform.up * shellInfo.MovementSpeed, ForceMode2D.Impulse);
        }

        public override void DiedBehaviour(ILevelModel levelModel, params object[] additionalParams)
        {

        }
    }
}
