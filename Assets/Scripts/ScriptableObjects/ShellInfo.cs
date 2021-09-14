using Asteroids.Abstraction;
using UnityEngine;

namespace Asteroids.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Gameplay/ShellInfo", fileName = "ShellInfo")]
    public class ShellInfo : ScriptableObject, IShellInfo
    {
        [SerializeField] private float _movementSpeed;
        public string ViewId3D => _viewId3D;

        [SerializeField] private string _viewId3D;
        public float MovementSpeed => _movementSpeed;
        
        public float RotationSpeed => _rotationSpeed;
        [SerializeField] private float _rotationSpeed;

        public int MaxHealth => _maxHealth;
        [SerializeField] private int _maxHealth;
        
        public int Health => _health;
        [SerializeField] private int _health;

        [SerializeField] private float _shellLifeTime;
        public float ShellLifeTime => _shellLifeTime;

        [SerializeField] private string _type;
        public string Type => _type;

        [SerializeField] private string _viewId;
        public string ViewId => _viewId;

        [SerializeField] private bool _destroyable;
        public bool Destroyable => _destroyable;

        [SerializeField] private BaseBehavior _shellBehavior;
        
        public BaseBehavior CreateShellBehavior()
        {
            return Instantiate(_shellBehavior);
        }

    }
}