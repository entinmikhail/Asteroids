using Asteroids.Abstraction;
using UnityEngine;

namespace Asteroids.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Gameplay/ShellInfo", fileName = "ShellInfo")]
    public class ShellInfo : ScriptableObject, IShellInfo
    {
        [SerializeField] private float _movementSpeed;
        public float MovementSpeed => _movementSpeed;

        [SerializeField] private float _shellLifeTime;
        public float ShellLifeTime => _shellLifeTime;

        [SerializeField] private string _type;
        public string Type => _type;

        [SerializeField] private string _viewId;
        public string ViewId => _viewId;

        [SerializeField] private bool _destroyable;
        public bool Destroyable => _destroyable;

        [SerializeField] private BaseShellBehavior _shellBehavior;
        public BaseShellBehavior ShellBehavior => _shellBehavior;
    }
}