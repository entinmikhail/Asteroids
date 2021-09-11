using System;

namespace Asteroids.Abstraction
{
    public delegate Action<int, int> ChargesChangeHandler(int curValue, int prevValue);
    public interface IWeapon
    {
        IWeaponInfo GetWeaponInfo();
        void ProduceFire();
        bool IsFireReady();
    }
}