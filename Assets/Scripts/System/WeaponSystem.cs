﻿using Asteroids.Abstraction;

namespace Asteroids.System
{
    public sealed class WeaponSystem : UpdateSystem<IWeapon>
    {
        protected override void Update(IWeapon item, double deltaTime)
        {
            if (item is IUpdatable weapon)
            {
                
                weapon.Update(deltaTime);
            }
        }
    }
}