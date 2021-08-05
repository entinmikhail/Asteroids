using System;
using Asteroids.Abstraction;
using Asteroids.ScriptableObjects;

namespace Asteroids.Model
{
    public class HealthModel : IHealthModel
    {
        private float _currentHealth;
        private readonly float _maxHealth;

        public event Action PlayerDied;
        public event HealthChangeHandler HealthIsChanged;

        public HealthModel(ShipInfo shipInfo)
        {
            _currentHealth = shipInfo.Health;
            _maxHealth = shipInfo.MaxHealth;
        }

        public float GetCurrentHealth() => _currentHealth;

        public void ChangeHealth(float changeValue)
        {
            var prevValue = _currentHealth;

            _currentHealth = Math.Min(_currentHealth + changeValue, _maxHealth);

            if (_currentHealth <= 0)
                PlayerDied?.Invoke();

            HealthIsChanged?.Invoke(_currentHealth, prevValue);
        }
    }
}