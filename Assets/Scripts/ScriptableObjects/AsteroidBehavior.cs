using Asteroids.Abstraction;
using UnityEngine;

namespace Asteroids.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Gameplay/ObjectsBehavior/AsteroidEnemyMoveBehavior", fileName = "AsteroidEnemyMoveBehavior")]
    public class AsteroidBehavior : BaseBehavior
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
            for (int i = 0; i < levelModel.GetInfo().MiniAsteroidsPerAsteroid; i++)
            {
                levelModel.SpawnTypedEnemy(levelModel.GetInfo().GetEnemyInfo("MiniAsteroid"), additionalParams[0]);
            }

            levelModel.SpawnTypedEnemy(levelModel.GetInfo().GetEnemyInfo("Asteroid"));
        }
    }
}