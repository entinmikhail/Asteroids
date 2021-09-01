using Asteroids.Abstraction;

namespace Asteroids.Model
{
    public class PointModel : ResourceModel, IPointModel

    {
        public PointModel(float currentResourceValue, float maxResourceValue) : base(currentResourceValue, maxResourceValue)
        {
        }

        public PointModel(float currentResourceValue) : base(currentResourceValue)
        {
        }
    }
}