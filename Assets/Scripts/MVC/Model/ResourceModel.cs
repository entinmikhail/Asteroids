using System;
using Asteroids.Abstraction;

namespace Asteroids.Model
{
    public class ResourceModel : IResourceModel
    {
        private float _currentResourceValue;
        private readonly float _maxResourceValue;

        public event Action ResourceEnded;
        public event ResourceChangeHandler ResourceValueChanged;
        
        public ResourceModel(float currentResourceValue, float maxResourceValue)
        {
            _currentResourceValue = currentResourceValue;
            _maxResourceValue = maxResourceValue;
        }

        public ResourceModel(float currentResourceValue)
        {
            _currentResourceValue = currentResourceValue;
            _maxResourceValue = float.MaxValue;
        }

        public float GetCurrentResourceValue() => _currentResourceValue;

        public void ChangeResource(float changeValue)
        {
            var prevValue = _currentResourceValue;

            _currentResourceValue = Math.Min(_currentResourceValue + changeValue, _maxResourceValue);
            
            if (_currentResourceValue <= 0)
                ResourceEnded?.Invoke();
            
            ResourceValueChanged?.Invoke(_currentResourceValue, prevValue);
        }

        public void SetResourceValue(float resourceValue)
        {
            _currentResourceValue = resourceValue;
        }
    }
}