using Asteroids.Abstraction;
using UnityEngine;

namespace Asteroids.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Gameplay/ObjectsBehavior/Player/PlayerMoveBehavior", fileName = "PlayerMoveBehavior")]
    public class PlayerMoveBehavior : BaseBehaviorUnity2D, IPlayerMoveBehavior
    {
        private IPlayerInfo _playerInfo;
        
        protected override void OnInit(params object[] additionalParams)
        {
            _playerInfo = (IPlayerInfo)additionalParams[0];
            var levelInfo = (ILevelInfo)additionalParams[1];
        }

        public void Rotate(float inputValue)
        {
            _playerViewUnity.Rigidbody2D.MoveRotation( _playerViewUnity.Rigidbody2D.rotation + -inputValue * 
                _playerInfo.RotationSpeed * Time.fixedDeltaTime);
        }

        public void Move(float inputValue)
        {
            _playerViewUnity.Rigidbody2D.AddForce(_playerViewUnity.Rigidbody2D.transform.up *
                                             (inputValue * _playerInfo.MovementSpeed * Time.fixedDeltaTime));

            _playerViewUnity.Rigidbody2D.velocity = GetNormalizedVelosity();
        }

        private Vector2 GetNormalizedVelosity()
        {
            return new Vector2(GetNormalizedSpeed(_playerViewUnity.Rigidbody2D.velocity.x), 
                GetNormalizedSpeed(_playerViewUnity.Rigidbody2D.velocity.y));
        }
        
        private float GetNormalizedSpeed(float curVelocity)
        {
            return Mathf.Min(Mathf.Abs(curVelocity), _playerInfo.MaxMovementSpeed) * Mathf.Sign(curVelocity);
        }

        public override void OnUpdate(ILevelObjectView view, IPlayerView playerView, float speed)
        {
        }
        public override void DiedBehaviour(ILevelModel levelModel, params object[] additionalParams)
        {

        }

        public override Vector3 GetStartPosition(ILevelManager _levelManager, IModel<IModelInfo> enemy)
        {
            return Vector3.zero;
        }
    }
}