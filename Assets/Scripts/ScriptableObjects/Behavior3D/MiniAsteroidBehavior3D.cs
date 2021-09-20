using Asteroids.Abstraction;
using UnityEngine;

namespace Asteroids.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Gameplay/ObjectsBehavior3D/MiniAsteroidEnemyMoveBehavior3D", fileName = "MiniAsteroidEnemyMoveBehavior3D")]
    public class MiniAsteroidBehavior3D : BaseBehaviorUnity3D
    {
        public override void OnUpdate (ILevelObjectView view, IPlayerView playerView, float speed)
        {
        }
        protected override void OnInit(params object[] additionalParams)
        {
            var speed = (float) additionalParams[0];
            var force = new Vector3(Random.Range(speed, -speed), Random.Range(speed, -speed), 0) ;
            
            _viewUnity.UnityTransform.SetPositionAndRotation(_viewUnity.UnityTransform.position +
                                                             force, Quaternion.identity);
            _viewUnity.Rigidbody.AddForce(force, ForceMode.Impulse);
        }

        public override void DiedBehaviour(ILevelModel levelModel, params object[] additionalParams)
        {
        }

        public override Vector3 GetStartPosition(ILevelManager _levelManager, IModel<IModelInfo> model)
        {
            var mini = (IMiniAsteroid) model;
            return mini.InitialPosition;
        }
    }
}