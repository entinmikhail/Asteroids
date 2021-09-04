using System.Collections.Generic;
using Asteroids.Abstraction;
using Asteroids.System;
using UnityEngine;

namespace Asteroids.Controller
{
    public class WeaponController
    {
        private WeaponSystem _updateManager;

        private GameModel _gameModel;
        private readonly IWeapon _weapon;
        private readonly IPlayerView _weaponView;
        private readonly WeaponSystem _weaponSystem;
        private List<BaseShell> _shellList = new List<BaseShell>();
        private BaseShell _shellComponent;
        
        public WeaponController(WeaponSystem weaponSystem, IPlayerView view, IWeapon weapon, BaseShell shell, GameModel gameModel)
        {
            _weaponSystem = weaponSystem;
            _weapon = weapon;
            _weaponView = view;
            _shellComponent = shell;
            _gameModel = gameModel;

            if (weapon is IWeapon updWeapon)
            {
                _weaponSystem.Add(updWeapon);
            }
        }

        public void Init()
        {
            _gameModel.GameRestarted += RemoveAllShell;
        }

        public void OnAttackClicked()
        {
            if (_weapon.IsFireReady())
            {
                
                var bullet = GameObject.Instantiate(_shellComponent, _weaponView.SpawnPoint);
                
                _shellList.Add(bullet);
                
                bullet.Fire(_weaponView.SpawnPoint.up);
                
                bullet.ShellDestroyed += RemoveShell;
                    
                _weapon.ProduceFire();
            }
        }
        
        private void RemoveShell(BaseShell shell)
        { 
            shell.ShellDestroyed -= RemoveShell;
            
            _shellList.Remove(shell);
            
            Object.Destroy(shell.gameObject);
        }

        private void RemoveAllShell()
        {
            for (int i = _shellList.Count - 1; i > 0; i--)
            {
                RemoveShell(_shellList[i]);
            }
        }
        
        public void Dispose()
        {
            _weaponSystem.Remove(_weapon);
        } 
    }
}