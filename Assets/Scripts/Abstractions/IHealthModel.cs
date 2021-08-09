using System;

namespace Asteroids.Abstraction
{
    public delegate Action<float, float> HealthChangeHandler(float curValue, float prevValue);
    
    public interface IHealthModel
    {
        public event Action Died;
    
        public event HealthChangeHandler HealthIsChanged;
        
        float GetCurrentHealth();
        
        void ChangeHealth(float changeValue);
    }
}