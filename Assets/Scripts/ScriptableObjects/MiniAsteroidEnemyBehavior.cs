using Asteroids.Abstraction;
using UnityEngine;

namespace Asteroids.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Gameplay/ObjectsBehavior/MiniAsteroidEnemyMoveBehavior", fileName = "MiniAsteroidEnemyMoveBehavior")]
    public class MiniAsteroidEnemyBehavior : BaseEnemyBehavior
    {
        public override void OnUpdate (ILevelObjectView view, IPlayerView playerView, float speed)
        {
        }

        public override void Init(ILevelObjectView view, IPlayerView playerView, params object[] additionalParams)
        {
            var speed = (float) additionalParams[0];
            var initialPosition = (Vector3) additionalParams[1];
            
            view.Transform.position = initialPosition;
            view.Rigidbody2D.AddForce(new Vector2(Random.Range(-speed, speed),
                Random.Range(-speed, speed)), ForceMode2D.Impulse);
        }

        public override void DiedBehaviour(ILevelModel levelModel, params object[] additionalParams)
        {
        }
    }
}