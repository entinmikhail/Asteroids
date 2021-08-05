using Asteroids.Abstraction;
using Asteroids.Controller;
using Asteroids.Core;
using Asteroids.Factories;
using Asteroids.Input;
using Asteroids.Model;
using Asteroids.ScriptableObjects;
using Asteroids.System;
using Asteroids.View;
using UnityEngine;

public class PlayerController
{
    private PlayerView _playerView;
    private PlayerInput _input;
    private MovementController _movementController;
    private WeaponController _weaponController;
    private WeaponSystem _weaponSystem;
    private HealthModel _healthModel;
    private WeaponModel _weapon;
    
    private IWeapon _firstWeapon;
    private IWeapon _secondWeapon;
    
    public PlayerController(PlayerView playerView)
    {
        _playerView = playerView;
    }

    public void Awake()
    {
        _weaponSystem = new WeaponSystem();
        _healthModel = new HealthModel(Resources.Load<ShipInfo>("ShipInfo"));
        /*_weaponController = new WeaponController(_weaponSystem, _playerView, _secondWeapon);*/
        
        _movementController = new MovementController(_playerView);
        var weaponFactory = new WeaponFactory(_playerView.SpawnPoint);
                
        /*_firstWeapon = weaponFactory.CreateDefoultWeapon();*/
        _secondWeapon = weaponFactory.CreateDefoultWeapon();
        
        _weapon = new WeaponModel(Resources.Load<WeaponInfo>("DefoultWeaponInfo"));
        _weaponController = new WeaponController(_weaponSystem, _playerView, _weapon, Resources.Load<Bullet>("Bullet"));
        
        _input = new PlayerInput();
        
        OnAwake();
    }

    public void Update()
    {
        _weaponSystem.Update(Time.deltaTime);

        _movementController.Move(_input.Player.Move.ReadValue<float>());
        _movementController.Rotate(_input.Player.Rotation.ReadValue<float>());
    }

    private void Dispose()
    {
        OnDisable();
        Object.Destroy(_playerView);
    }
    private void OnAwake()
    {
        _input.Enable();
        
        _input.Player.Fire1.performed += _ => _weaponController.OnAttackClicked();
        _input.Player.Fire2.performed += _ => _secondWeapon.ProduceFire();
        _healthModel.PlayerDied += Dispose;
    }

    private void OnDisable()
    {
        _input.Disable();
    }
}
