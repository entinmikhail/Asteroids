using System;

namespace Asteroids.Abstraction
{
    public delegate Action<int, int> ChargesChangeHandler(int curValue, int prevValue);
    public interface IWeapon : IUpdatable
    {
        event Action Shot;
        event ChargesChangeHandler ChargesChangeHandler;
        IWeaponInfo GetWeaponInfo();
        void ProduceFire();
        void ClearCooldown();
    }
}