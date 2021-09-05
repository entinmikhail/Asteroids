namespace Asteroids.Abstraction
{
    public interface IShipInfo
    {
        float MovementSpeed { get; }
        
        float MaxMovementSpeed { get; }
    
        float RotationSpeed { get; }
    
        int MaxHealth { get; }
    
        int Health { get; }
    }
}