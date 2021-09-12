using System;
using Asteroids.Abstraction;
using Asteroids.ScriptableObjects;

namespace Asteroids.Model
{
    public class WeaponModel : IWeapon, IUpdatable
    {
        private readonly IWeaponInfo _weaponInfo;

        private int _remainingCharges;
        private int _prevCharges;
        private double _currentChargeTime = 0f;
        private float _nextChargeTime;

        public event Action Shoting;
        public event ChargesChangeHandler ChargesChangeHandler;

        public WeaponModel(IWeaponInfo weaponInfo)
        {
            _weaponInfo = weaponInfo;
            _remainingCharges = _weaponInfo.MaxСharges;
        }
        
        public IWeaponInfo GetWeaponInfo() => _weaponInfo;

        public void Update(double deltaTime)
        {
            UpdateCooldown(deltaTime);
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
        
        private void UpdateCooldown(double deltaTime)
        {
            if (_remainingCharges < _weaponInfo.MaxСharges)
            {
                _currentChargeTime += deltaTime;

                if (_currentChargeTime >= _weaponInfo.Cooldown)
                {
                    _remainingCharges++;
                    _currentChargeTime = 0f;
                }
            }
        }
    }
}

