using Asteroids.Abstraction;
using UnityEngine;

namespace Asteroids.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Gameplay/WeaponInfo", fileName = "WeaponInfo")]
    public class WeaponInfo : ScriptableObject
    {
        public float AttackSpeed => _attackSpeed;
        [SerializeField] private float _attackSpeed;

        public float Cooldown => _cooldown;
        [SerializeField] private float _cooldown;
    
        public int MaxСharges => _maxСharges;
        [SerializeField] private int _maxСharges;
    }   
}
