using Asteroids.Abstraction;
using UnityEngine;

namespace Asteroids.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Gameplay/ObjectsBehavior/LaserBehavior", fileName = "LaserBehavior")]
    public class LaserBehavior : BaseBehavior
    
    {
        public override void OnUpdate (ILevelObjectView view, IPlayerView playerView, float speed)
        {
            
        } 

        protected override void OnInit(params object[] additionalParams)
        {
            _viewUnity.UnityTransfom.Rotate(_playerViewUnity.UnityTransfom.rotation.eulerAngles);
        }

        public override void DiedBehaviour(ILevelModel levelModel, params object[] additionalParams)
        {

        }
    }
}