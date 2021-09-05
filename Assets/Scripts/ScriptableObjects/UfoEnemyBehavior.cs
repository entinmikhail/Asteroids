using Asteroids.Abstraction;
using UnityEngine;

namespace Asteroids.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Gameplay/ObjectsBehavior/UFOEnemyMoveBehavior", fileName = "UFOEnemyMoveBehavior")]
    public class UfoEnemyBehavior : BaseEnemyBehavior
    {
        public override void OnUpdate (ILevelObjectView view, IPlayerView playerView, float speed)
        {
            view.Transform.position = Vector2.MoveTowards(view.Transform.position,
                playerView.Transform.position, speed * Time.deltaTime); 
        }

        public override void Init(ILevelObjectView view, IPlayerView playerView, params object[] additionalParams)
        {
            
        }

        public override void DiedBehaviour(ILevelModel levelModel, params object[] additionalParams)
        {
            levelModel.SpawnTypedEnemy(levelModel.GetInfo().GetEnemyInfo("UFO"));
        }
    }
}