namespace Asteroids.Abstraction
{
    public interface IModelInfo
    {
        float MovementSpeed { get; }
        public float RotationSpeed  { get; }
        public int MaxHealth  { get; }
        int Health { get; }
    }
}