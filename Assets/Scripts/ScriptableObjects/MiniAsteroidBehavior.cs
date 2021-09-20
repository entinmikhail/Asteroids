using Asteroids.Abstraction;
using UnityEngine;

namespace Asteroids.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Gameplay/ObjectsBehavior/MiniAsteroidEnemyMoveBehavior", fileName = "MiniAsteroidEnemyMoveBehavior")]
    public class MiniAsteroidBehavior : BaseBehaviorUnity2D
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
            _viewUnity.Rigidbody2D.AddForce(force, ForceMode2D.Impulse);
        }

        public override void DiedBehaviour(ILevelModel levelModel, params object[] additionalParams)
        {
        }

        public override Vector3 GetStartPosition(ILevelManager levelManager, IModel<IModelInfo> enemy)
        {
            var mini = (IMiniAsteroid) enemy;
            return mini.InitialPosition;
        }
    }
}