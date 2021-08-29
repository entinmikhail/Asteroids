using System;
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
    private HealthModel _healthModel;
    
    private PlayerView _playerView;
    private PlayerInput _input;
    private MovementController _movementController;
    private WeaponController _weaponController;
    private WeaponSystem _weaponSystem;
    private WeaponModel _weapon;

    private IWeapon _firstWeapon;
    private IWeapon _secondWeapon;

    public Action PlayerDead;
    public PlayerController(PlayerView playerView, HealthModel healthModel)
    {
        _playerView = playerView;
        _healthModel = healthModel;
    }

    public void Awake()
    {
        var shipInfo = Resources.Load<ShipInfo>("ShipInfo");
        
        _weaponSystem = new WeaponSystem();
        
        
        _movementController = new MovementController(_playerView);
        var weaponFactory = new WeaponFactory(_playerView.SpawnPoint);
        
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
    
    private void OnAwake()
    {
        OnEnable();
            
        _input.Player.Enable();
        
        _input.Player.Fire1.Enable();
        _input.Player.Fire2.Enable();
        
        _input.Player.Move.Enable();
        _input.Player.Rotation.Enable();
        
        _input.Player.Fire1.performed += _ => _weaponController.OnAttackClicked();
        _input.Player.Fire2.performed += _ => _secondWeapon.ProduceFire();
        
        _healthModel.ResourceEnded += OnPlayerResourceEnded;
        _playerView.OnGameObjectContact += OnCollision;
    }

    private void Dispose()
    {
        OnDisable();
    }
    
    private void OnPlayerResourceEnded()
    {
        Dispose();
        PlayerDead?.Invoke();
    }
    
    public void OnDisable()
    {
        _input.Disable();
    }

    public void OnEnable()
    {
        _input.Enable();
    }
    private void OnCollision(GameObject obj)
    {
        if (obj.CompareTag("Enemy"))
        {
            _healthModel.ChangeResource(-1.0f);
        }
    }
}
