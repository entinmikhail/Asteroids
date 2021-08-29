using System;

namespace Asteroids.Abstraction
{
    public interface IHealthModel
    {
        public event Action ResourceEnded;

        void SetResourceValue(float resourceValue);
         
        float GetCurrentResourceValue();
        
        void ChangeResource(float changeValue);
    }
}