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
            
            _viewUnity.Rigidbody2D.AddForce(new Vector2(Random.Range(-speed, speed),
                Random.Range(-speed, speed)), ForceMode2D.Impulse);
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