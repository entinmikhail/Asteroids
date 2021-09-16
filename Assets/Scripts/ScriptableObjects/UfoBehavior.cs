using Asteroids.Abstraction;
using UnityEngine;

namespace Asteroids.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Gameplay/ObjectsBehavior/UFOEnemyMoveBehavior", fileName = "UFOEnemyMoveBehavior")]
    public class UfoBehavior : BaseBehaviorUnity, IUfoBehaviour
    {
        private bool _stopped = false;
        public void Stop()
        {
            _stopped = true;
        }
        
        public override void OnUpdate (ILevelObjectView view, IPlayerView playerView, float speed)
        {
            if(_stopped) return;
            if (view is ILevelObjectViewUnity viewUnity &&  playerView is IPlayerViewUnity2D playerViewUnity)
                DoSomeThing(viewUnity, playerViewUnity, speed);
        }
        protected override void OnInit(params object[] additionalParams)
        {
            _stopped = false;
        }

        public override void DiedBehaviour(ILevelModel levelModel, params object[] additionalParams)
        {
            levelModel.SpawnTypedEnemy(levelModel.GetInfo().GetEnemyInfo("UFO"));
        }
        
        private void DoSomeThing(ILevelObjectViewUnity unityView, IPlayerViewUnity2D playerUnity2DView, float speed)
        {
            unityView.UnityTransform.position = Vector2.MoveTowards(unityView.UnityTransform.position,
                playerUnity2DView.UnityTransform.position, speed * Time.deltaTime);
        }
    }
}