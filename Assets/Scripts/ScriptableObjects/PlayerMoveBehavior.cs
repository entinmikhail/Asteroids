using Asteroids.Abstraction;
using UnityEngine;

namespace Asteroids.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Gameplay/ObjectsBehavior/Player/PlayerMoveBehavior", fileName = "PlayerMoveBehavior")]
    public class PlayerMoveBehavior : ScriptableObject, IPlayerMoveBehavior
    {
        private IPlayerView _playerView;
        private IPlayerInfo _playerInfo;

        public void Init(IPlayerView playerView, IPlayerInfo playerInfo)
        {
            _playerView = playerView;
            _playerInfo = playerInfo;
        }
        
        public void Rotate(float inputValue)
        {
            _playerView.Rigidbody2D.MoveRotation( _playerView.Rigidbody2D.rotation + -inputValue * _playerInfo.RotationSpeed * Time.fixedDeltaTime);
        }

        public void Move(float inputValue)
        {
            _playerView.Rigidbody2D.AddForce(_playerView.Rigidbody2D.transform.up *
                                             (inputValue * _playerInfo.MovementSpeed * Time.fixedDeltaTime));

            _playerView.Rigidbody2D.velocity = GetNormalizedVelosity();
        }

        private Vector2 GetNormalizedVelosity()
        {
            return new Vector2(GetNormalizedSpeed(_playerView.Rigidbody2D.velocity.x), 
                GetNormalizedSpeed(_playerView.Rigidbody2D.velocity.y));
        }
        
        private float GetNormalizedSpeed(float curVelocity)
        {
            return Mathf.Min(Mathf.Abs(curVelocity), _playerInfo.MaxMovementSpeed) * Mathf.Sign(curVelocity);
        }
    }
}