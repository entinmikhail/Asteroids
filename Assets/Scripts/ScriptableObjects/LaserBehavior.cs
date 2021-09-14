using Asteroids.Abstraction;
using UnityEngine;

namespace Asteroids.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Gameplay/ObjectsBehavior/LaserBehavior", fileName = "LaserBehavior")]
    public class LaserBehavior : BaseBehaviorUnity

    {
    public override void OnUpdate(ILevelObjectView view, IPlayerView playerView, float speed)
    {

    }

    protected override void OnInit(params object[] additionalParams)
    {
        _viewUnity.UnityTransform.Rotate(_playerViewUnity.UnityTransform.rotation.eulerAngles);
    }

    public override void DiedBehaviour(ILevelModel levelModel, params object[] additionalParams)
    {

    }
    }
}