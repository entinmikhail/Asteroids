using System;
using Asteroids.Abstraction;

namespace Asteroids.Model
{
    public class HealthModel : IHealthModel
    {
        private float _currentHealth;
        private readonly float _maxHealth;

        public event Action Died;
        public event HealthChangeHandler HealthIsChanged;

        public HealthModel(IHealth health)
        {
            _currentHealth = health.Health;
            _maxHealth = health.MaxHealth;
        }

        public float GetCurrentHealth() => _currentHealth;

        public void ChangeHealth(float changeValue)
        {
            var prevValue = _currentHealth;

            _currentHealth = Math.Min(_currentHealth + changeValue, _maxHealth);
            if (_currentHealth <= 0)
                Died?.Invoke();

            HealthIsChanged?.Invoke(_currentHealth, prevValue);
        }
    }
}