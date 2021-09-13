using Asteroids.Abstraction;
using UnityEngine;

namespace Asteroids.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Gameplay/EnemyInfo", fileName = "EnemyInfo")]
    public class EnemyInfo : ScriptableObject, IEnemyInfo
    {
        
        public float MovementSpeed => _movementSpeed;
        [SerializeField] private float _movementSpeed;

        public float RotationSpeed => _rotationSpeed;
        [SerializeField] private float _rotationSpeed;
    
        public int MaxHealth => _maxHealth;
        [SerializeField] private int _maxHealth;
    
        public int Health => _health;
        [SerializeField] private int _health;

        public string ViewId => _viewId;
        [SerializeField] private string _viewId;

        public string Type => _type;
        [SerializeField] private string _type;

        public int PointsForKill => _pointsForKill;
        [SerializeField] private int _pointsForKill;
        
        public BaseEnemyBehavior EnemyBehavior => _enemyBehavior;
        [SerializeField] private BaseEnemyBehavior _enemyBehavior;
    }   
}
