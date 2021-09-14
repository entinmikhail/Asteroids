using Asteroids.Abstraction;
using UnityEngine;

namespace Asteroids.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Gameplay/WeaponInfo", fileName = "WeaponInfo")]
    public class WeaponInfo : ScriptableObject, IWeaponInfo
    {
        public float Cooldown => _cooldown;
        [SerializeField] private float _cooldown;
        public int MaxСharges => _maxСharges;
        [SerializeField] private int _maxСharges;
        
        public float DamageValue => _damageValue;
        [SerializeField] private float _damageValue;
    }   
}
