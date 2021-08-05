using System;

namespace Asteroids.Abstraction
{
    public delegate Action<int, int> ChargesChangeHandler(int curValue, int prevValue);
    public interface IWeapon
    {
        void ProduceFire();
        bool IsFireReady();
    }
}