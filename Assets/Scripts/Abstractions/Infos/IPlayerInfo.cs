
namespace Asteroids.Abstraction
{
    public interface IPlayerInfo 
    {
        float MovementSpeed { get; }
        
        float MaxMovementSpeed { get; }
    
        float RotationSpeed { get; }
    
        int MaxHealth { get; }
    
        int Health { get; }
        
        IPlayerMoveBehavior PlayerMoveBehavior { get; }
    }
}