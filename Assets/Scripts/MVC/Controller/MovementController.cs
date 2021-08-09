using Asteroids.Abstraction;
using Asteroids.ScriptableObjects;
using Asteroids.View;
using UnityEngine;

namespace Asteroids.Controller
{
    public class MovementController
    {
        private PlayerView _playerView;
        private ShipInfo _shipInfo;
        public MovementController(PlayerView playerView)
        {
            _playerView = playerView;
            _shipInfo = Resources.Load<ShipInfo>("ShipInfo");
        }

        public void Rotate(float inputValue)
        {
            _playerView.Rigidbody2D.MoveRotation( _playerView.Rigidbody2D.rotation + -inputValue * _shipInfo.RotationSpeed * Time.fixedDeltaTime);
        }

        public void Move(float inputValue)
        {
            _playerView.Rigidbody2D.AddForce(_playerView.Rigidbody2D.transform.up *
                                             (inputValue * _shipInfo.MovementSpeed * Time.fixedDeltaTime));

            _playerView.Rigidbody2D.velocity = GetNormalizedVelosity();
            /*_ship.SetPosition(_playerView.Transform.position);*/
        }

        private Vector2 GetNormalizedVelosity()
        {
            return new Vector2(GetNormalizedSpeed(_playerView.Rigidbody2D.velocity.x), 
                GetNormalizedSpeed(_playerView.Rigidbody2D.velocity.y));
        }
        private float GetNormalizedSpeed(float curVelocity)
        {
           return Mathf.Min(Mathf.Abs(curVelocity), _shipInfo.MaxMovementSpeed) * Mathf.Sign(curVelocity);
        }
    }
}
