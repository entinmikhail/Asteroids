using System;
using Asteroids.Abstraction;
using Asteroids.ScriptableObjects;
using UnityEngine;

namespace Asteroids.Model
{
    public class WeaponModel : IWeapon, IUpdatable
    {
        private readonly WeaponInfo _weaponInfo;

        private int _remainingCharges;
        private int _prevCharges;
        private float _currentChargeTime = 0f;
        private float _nextChargeTime;

        public event Action Shoting;
        public event ChargesChangeHandler ChargesChangeHandler;

        public WeaponModel(WeaponInfo weaponInfo)
        {
            _weaponInfo = weaponInfo;
            _remainingCharges = _weaponInfo.MaxСharges;
        }

        public void Update(double deltaTime)
        {
            UpdateCooldown();
        }
        
        public void ProduceFire()
        {
            var prevCharges = _remainingCharges;
            
            _remainingCharges--;
            
            ChargesChangeHandler?.Invoke(_remainingCharges, _prevCharges);
            Shoting?.Invoke();
        }

        public bool IsFireReady()
        {
            return _remainingCharges > 0;
        }
        
        private void UpdateCooldown()
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
    }
}

