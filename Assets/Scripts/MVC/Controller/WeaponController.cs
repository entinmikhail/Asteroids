using Asteroids.Abstraction;
using Asteroids.Core;
using Asteroids.System;
using UnityEngine;

namespace Asteroids.Controller
{
    public class WeaponController
    {
        private WeaponSystem _updateManager;

        
        private readonly IWeapon _weapon;
        private readonly IPlayerView _weaponView;
        private readonly WeaponSystem _weaponSystem;
        private Bullet _bullet;

        public WeaponController(WeaponSystem weaponSystem, IPlayerView view, IWeapon weapon, Bullet bullet)
        {
            _weaponSystem = weaponSystem;
            _weapon = weapon;
            _weaponView = view;
            _bullet = bullet;

            if (weapon is IWeapon updWeapon)
            {
                _weaponSystem.Add(updWeapon);
            }
        }

        public void OnAttackClicked()
        {
            if (_weapon.IsFireReady())
            {
                var bullet = GameObject.Instantiate(_bullet, _weaponView.SpawnPoint);
                bullet.Fire(_weaponView.SpawnPoint.up);
                    
                _weapon.ProduceFire();
            }
        }
                
        public void Dispose()
        {
            _weaponSystem.Remove(_weapon);
        } 
    }
}