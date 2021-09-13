using Asteroids.Abstraction;
using UnityEngine;


namespace Asteroids.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Gameplay/ShipInfo", fileName = "ShipInfo")]
    public class PlayerInfo : ScriptableObject, IPlayerInfo
    {
        public string ViewId => _viewId;
        [SerializeField] private string _viewId;
        public float MovementSpeed => _movementSpeed;
        [SerializeField] private float _movementSpeed;
        
        public float MaxMovementSpeed => _maxMovementSpeed;
        [SerializeField] private float _maxMovementSpeed;
    
        public float RotationSpeed => _rotationSpeed;
        [SerializeField] private float _rotationSpeed;
    
        public int MaxHealth => _maxHealth;
        [SerializeField] private int _maxHealth;
    
        public int Health => _health;
        [SerializeField] private int _health;

        public IPlayerMoveBehavior PlayerMoveBehavior => _playerMoveBehavior; 
        [SerializeField] private PlayerMoveBehavior _playerMoveBehavior;
    }
}
