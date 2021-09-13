using Asteroids.Abstraction;

namespace Asteroids.Model
{
    public class HealthModel : ResourceModel

    {
        private readonly bool _isPlayerLife;
        
        public HealthModel(float currentResourceValue, float maxResourceValue) : base(currentResourceValue, maxResourceValue)
        {
            
        }

        public HealthModel(float currentResourceValue) : base(currentResourceValue)
        {
            
        }
    }
}