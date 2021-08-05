namespace Asteroids.Abstraction
{
    public interface IShip
    {
        IWeapon FirstWeapon { get; }
        IWeapon SecondWeapon { get; }
    }
}