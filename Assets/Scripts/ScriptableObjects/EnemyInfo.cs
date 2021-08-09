using Asteroids.Abstraction;
using UnityEngine;

namespace Asteroids.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Gameplay/EnemyInfo", fileName = "EnemyInfo")]
    public class EnemyInfo : ScriptableObject, IHealth
    {
        public float MovementSpeed => _movementSpeed;
        [SerializeField] private float _movementSpeed;

        public float RotationSpeed => _rotationSpeed;
        [SerializeField] private float _rotationSpeed;
    
        public int MaxHealth => _maxHealth;
        [SerializeField] private int _maxHealth;
    
        public int Health => _health;
        [SerializeField] private int _health;
    }   
}
