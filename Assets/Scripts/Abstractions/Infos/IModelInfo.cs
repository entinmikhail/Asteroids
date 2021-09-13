namespace Asteroids.Abstraction
{
    public interface IModelInfo
    {
        public string ViewId { get; }
        float MovementSpeed { get; }
        public float RotationSpeed  { get; }
        public int MaxHealth  { get; }
        int Health { get; }
    }
}