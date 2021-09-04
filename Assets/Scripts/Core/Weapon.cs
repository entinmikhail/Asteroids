using Asteroids.Abstraction;
using Asteroids.ScriptableObjects;
using UnityEngine;


namespace Asteroids.Core
{
    public class Weapon : IWeapon
    {
        private WeaponInfo _weaponInfo;
        private BaseShell _bullet;
        private Transform _spawnPoint;

        private int _remainingCharges;
        private float _currentChargeTime = 0f;
        private float _nextChargeTime;

        public Weapon(WeaponInfo weaponInfo, BaseShell bullet, Transform spawnPoint)
        {
            _weaponInfo = weaponInfo;
            _bullet = bullet;
            _spawnPoint = spawnPoint;
            _remainingCharges = _weaponInfo.MaxСharges;
        }

        public void ProduceFire()
        {
            if (IsFireReady())
            {
                var bullet = GameObject.Instantiate(_bullet, _spawnPoint);
                bullet.Fire(_spawnPoint.up);
                _remainingCharges--;
            }
        }

        public void UpdateCooldown()
        {
            if (_remainingCharges < _weaponInfo.MaxСharges)
            {
                _currentChargeTime += Time.deltaTime;   

                if (_currentChargeTime >= _weaponInfo.Cooldown)
                {
                    _remainingCharges++;
                    _currentChargeTime = 0f;
                }
            }
        }
        
        public bool IsFireReady()
        {
            return _remainingCharges > 0;
        }
    }
}
