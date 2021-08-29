using System;

namespace Asteroids.Abstraction
{
    public interface IResourceModel
    {
        public event Action ResourceEnded;
    
        public event Action<float, float> ResourceValueChanged;
        
        float GetCurrentResourceValue();
        
        void ChangeResource(float changeValue);
    }
}