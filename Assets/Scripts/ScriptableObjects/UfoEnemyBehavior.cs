using Asteroids.Abstraction;
using UnityEngine;

namespace Asteroids.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Gameplay/ObjectsBehavior/UFOEnemyMoveBehavior", fileName = "UFOEnemyMoveBehavior")]
    public class UfoEnemyBehavior : BaseEnemyBehavior, ISerializationCallbackReceiver
    {
        private bool _stopped = false;
        public void Stop()
        {
            _stopped = true;
        }
        
        public override void OnUpdate (ILevelObjectView view, IPlayerView playerView, float speed)
        {
            if(_stopped) return;
            
            view.Transform.position = Vector2.MoveTowards(view.Transform.position,
                playerView.Transform.position, speed * Time.deltaTime); 
        }

        public override void Init(ILevelObjectView view, IPlayerView playerView, params object[] additionalParams)
        {
            _stopped = false;
        }

        public override void DiedBehaviour(ILevelModel levelModel, params object[] additionalParams)
        {
            levelModel.SpawnTypedEnemy(levelModel.GetInfo().GetEnemyInfo("UFO"));
        }

        public void OnBeforeSerialize()
        {
            _stopped = false;
        }

        public void OnAfterDeserialize()
        {
            _stopped = false;
        }
    }
}