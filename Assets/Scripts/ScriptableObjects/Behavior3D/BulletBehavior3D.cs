using Asteroids.Abstraction;
using UnityEngine;

namespace Asteroids.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Gameplay/ObjectsBehavior3D/BulletBehavior3D", fileName = "BulletBehavior3D")]
    public class BulletBehavior3D : BaseBehaviorUnity3D
    
    {
        public override void OnUpdate (ILevelObjectView view, IPlayerView playerView, float speed)
        {
            
        }
        
        protected override void OnInit(params object[] additionalParams)
        {
            var shellInfo = (IShellInfo) additionalParams[0];
            _viewUnity.Rigidbody.AddForce(_playerViewUnity.SpawnPoint.transform.up * 
                                          shellInfo.MovementSpeed, ForceMode.Impulse);
        }

        public override void DiedBehaviour(ILevelModel levelModel, params object[] additionalParams)
        {

        }

        public override Vector3 GetStartPosition(ILevelManager levelManager, IModel<IModelInfo> enemy)
        {
            return _playerViewUnity.SpawnPoint.position;
        }
    }
}
