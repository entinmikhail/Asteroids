namespace Asteroids.Abstraction
{
    public interface IWeaponInfo
    {
        float Cooldown  { get; }
        int MaxСharges  { get; }
        float DamageValue { get; }
    }
}