using Asteroids.Abstraction;
using UnityEngine;

namespace Asteroids.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Gameplay/ObjectsBehavior3D/UFOEnemyMoveBehavior3D", fileName = "UFOEnemyMoveBehavior3D")]
    public class UfoBehavior3D : BaseBehaviorUnity3D, IUfoBehaviour
    {
        private bool _stopped = false;
        public void Stop()
        {
            _stopped = true;
        }
        
        public override void OnUpdate (ILevelObjectView view, IPlayerView playerView, float speed)
        {
            if(_stopped) return;
            if (view is ILevelObjectViewUnity viewUnity &&  playerView is IPlayerViewUnity3D playerViewUnity)
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

        public override Vector3 GetStartPosition(ILevelManager levelManager, IModel<IModelInfo> enemy)
        {
            var levelInfo = levelManager.GetCurrentLevel().GetInfo();
            
            return new Vector3(Random.Range(levelInfo.LevelBounds.min.x, levelInfo.LevelBounds.max.x),
                Random.Range(levelInfo.LevelBounds.min.y, levelInfo.LevelBounds.max.y),
                Random.Range(levelInfo.LevelBounds.min.z, levelInfo.LevelBounds.max.z));
        }


        private void DoSomeThing(ILevelObjectViewUnity unityView, IPlayerViewUnity3D playerUnity2DView, float speed)
        {
            unityView.UnityTransform.position = Vector3.MoveTowards(unityView.UnityTransform.position,
                playerUnity2DView.UnityTransform.position, speed * Time.deltaTime);
        }
    }
}