using System.Collections.Generic;
using Asteroids.Abstraction;
using UnityEngine;

namespace Asteroids.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Gameplay/EnemyInfo", fileName = "EnemyInfo")]
    public class EnemyInfo : ScriptableObject, IEnemyInfo
    {
        public string ViewId3D => _viewId3D;

        [SerializeField] private string _viewId3D;
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
        
        [SerializeField] private BaseBehavior _enemyBehavior;
        [SerializeField] private BaseBehavior _enemyBehavior3D;
        
        public BaseBehavior GetBehavior(ViewMode viewMode)
        {
            switch (viewMode)
            {
                case  ViewMode.Poligone:
                    return _enemyBehavior3D;

                default:
                    return _enemyBehavior;
            }
        }
    }   
}
