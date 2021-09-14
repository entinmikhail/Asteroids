using Asteroids.Abstraction;
using UnityEngine;

namespace Asteroids.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Gameplay/ObjectsBehavior3D/AsteroidEnemyMoveBehavior3D", fileName = "AsteroidEnemyMoveBehavior3D")]
    public class AsteroidBehavior3D : BaseBehaviorUnity3D
    {
        public override void OnUpdate (ILevelObjectView view, IPlayerView playerView, float speed)
        {
        }
        protected override void OnInit(params object[] additionalParams)
        {
            var speed = (float) additionalParams[0];
            _viewUnity.Rigidbody.AddForce(new Vector2(Random.Range(-speed, speed),
                Random.Range(-speed, speed)), ForceMode.Impulse);
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