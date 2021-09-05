using Asteroids.Abstraction;
using Asteroids.Core;
using Asteroids.ScriptableObjects;
using UnityEngine;

namespace Asteroids.Factories
{
    public class WeaponFactory
    {
        private Transform _spawnPoint;

        public WeaponFactory(Transform spawnPoint)
        {
            _spawnPoint = spawnPoint;
        }

        public IWeapon CreateDefoultWeapon()
        {
            return new Weapon(Resources.Load<WeaponInfo>("DefoultWeaponInfo"), Resources.Load<Bullet>("Laser"), _spawnPoint);
        }
    } 
}

