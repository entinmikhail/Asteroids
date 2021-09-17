using Asteroids.Abstraction;
using UnityEngine;

namespace Asteroids.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Gameplay/ObjectsBehavior3D/Player/PlayerMoveBehavior3D", fileName = "PlayerMoveBehavior3D")]
    public class PlayerMoveBehavior3D :  BaseBehaviorUnity3D, IPlayerMoveBehavior
    {
        private IPlayerInfo _playerInfo;
        private Vector3 _vector3;
        
        protected override void OnInit(params object[] additionalParams)
        {
            _playerInfo = (IPlayerInfo)additionalParams[0];
            _vector3 =  new Vector3(0, 0, 1);
        }

        public void Rotate(float inputValue)
        {
            _playerViewUnity.Rigidbody.MoveRotation(Quaternion.Euler(_playerViewUnity.Rigidbody.rotation.eulerAngles +
                                                                     _vector3 * -inputValue * _playerInfo.RotationSpeed * Time.deltaTime));
        }

        public void Move(float inputValue)
        {
            _playerViewUnity.Rigidbody.AddForce(_playerViewUnity.Rigidbody.transform.up *
                                                (inputValue * _playerInfo.MovementSpeed * 20 * Time.deltaTime));

            _playerViewUnity.Rigidbody.velocity = GetNormalizedVelosity();
        }

        private Vector2 GetNormalizedVelosity()
        {
            return new Vector2(GetNormalizedSpeed(_playerViewUnity.Rigidbody.velocity.x), 
                GetNormalizedSpeed(_playerViewUnity.Rigidbody.velocity.y));
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

        public override Vector3 GetStartPosition(ILevelManager levelManager, IModel<IModelInfo> enemy)
        {
            return Vector3.zero;
        }
    }
}