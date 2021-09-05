namespace Asteroids.Abstraction
{
    public interface IWeaponInfo
    {
        float AttackSpeed  { get; }
        float Cooldown  { get; }
        int MaxСharges  { get; }
        float DamageValue { get; }
    }
}