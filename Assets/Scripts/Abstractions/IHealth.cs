namespace Asteroids.Abstraction
{
    public interface IHealth
    {
        int MaxHealth { get; }

        int Health { get; }
    }
}