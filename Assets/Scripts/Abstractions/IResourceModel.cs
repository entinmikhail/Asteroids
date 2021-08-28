using System;

namespace Asteroids.Abstraction
{
    public delegate Action<float, float> ResourceChangeHandler(float curValue, float prevValue);
    
    public interface IResourceModel
    {
        public event Action ResourceEnded;
    
        public event ResourceChangeHandler ResourceValueChanged;
        
        float GetCurrentResourceValue();
        
        void ChangeResource(float changeValue);
    }
}