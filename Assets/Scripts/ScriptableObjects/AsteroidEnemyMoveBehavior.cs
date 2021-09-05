using Asteroids.Abstraction;
using UnityEngine;

namespace Asteroids.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Gameplay/ObjectsBehavior/AsteroidEnemyMoveBehavior", fileName = "AsteroidEnemyMoveBehavior")]
    public class AsteroidEnemyMoveBehavior : BaseEnemyMoveBehavior
    {
        public override void OnUpdate (ILevelObjectView view, IPlayerView playerView, float speed)
        {
           
        }

        public override void Init(ILevelObjectView view, IPlayerView playerView, float speed)
        {
            view.Rigidbody2D.AddForce(new Vector2(Random.Range(-speed, speed),
                Random.Range(-speed, speed)), ForceMode2D.Impulse);
        }
    }
}