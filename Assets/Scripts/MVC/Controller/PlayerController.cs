using System;
using Asteroids.Abstraction;
using Asteroids.Controller;
using Asteroids.Model;
using Asteroids.ScriptableObjects;
using Asteroids.System;
using Asteroids.View;
using UnityEngine;

public class PlayerController : IUpdatable, IController
{
    private HealthModel _healthModel;
    private readonly PlayerView _playerView;
    private IInputHandler _inputHandler;
    private IPlayerMoveBehavior _playerMoveBehavior;
    private BulletWeaponController _bulletWeaponController;
    private LaserWeaponController _laserWeponController;
    private WeaponSystem _weaponSystem;
    private WeaponModel _weaponModel;
    private GameModel _gameModel;
    private PlayerInfo _playerInfo;
    private ILevelManager _levelManager;
    private PlayerCollisionHandler _collisionHandler;
    public event Action PlayerDead;
    public PlayerController(PlayerView playerView, HealthModel healthModel, GameModel gameModel, PlayerInfo playerInfo, IInputHandler inputHandler, ILevelManager levelManager)
    {
        _playerView = playerView;
        _healthModel = healthModel;
        _gameModel = gameModel;
        _playerInfo = playerInfo;
        _inputHandler = inputHandler;
        _levelManager = levelManager;
        _collisionHandler = new PlayerCollisionHandler(_playerView);
    }

    public void Start()
    {
        _healthModel.SetResourceValue(_playerInfo.Health);
        
        /*
        _playerGameObject.SetActive(true);

        _playerGameObject.transform.SetPositionAndRotation(_defaultPlayerPosition, _defaultRotation);
        */
        
        _weaponSystem = new WeaponSystem();

        _playerMoveBehavior = _playerInfo.PlayerMoveBehavior;
        _playerMoveBehavior.Init(_playerView, _playerInfo);
        _collisionHandler.Init();
         
        _bulletWeaponController = new BulletWeaponController(_weaponSystem, new WeaponModel(Resources.Load<WeaponInfo>("BulletWeaponInfo")),
            Resources.Load<ShellInfo>("ShellInfo/BulletInfo"),_levelManager);
        _laserWeponController = new LaserWeaponController(_weaponSystem, new WeaponModel(Resources.Load<WeaponInfo>("LaserWeaponInfo")),
            Resources.Load<ShellInfo>("ShellInfo/LaserInfo"), _levelManager);

        Attach();
    }

    public void Update(double deltaTime)
    { 
        _weaponSystem.Update(deltaTime);
    }
    
    private void Attach()
    {
        _inputHandler.Fire1Clicked += _bulletWeaponController.OnAttackClicked;
         _inputHandler.Fire2Clicked += _laserWeponController.OnAttackClicked;
        _inputHandler.MoveClicked += _playerMoveBehavior.Move;
        _inputHandler.RotationClicked += _playerMoveBehavior.Rotate;
        
        _healthModel.ResourceEnded += OnPlayerResourceEnded;
        _collisionHandler.OnGameObjectContact += OnCollision;
    }
    
    public void Dispose()
    {
        Detach();
        
        _bulletWeaponController.Dispose();
        _laserWeponController.Dispose();
        _collisionHandler.Dispose();
    }

    private void Detach()
    {
        _inputHandler.Fire1Clicked -= _bulletWeaponController.OnAttackClicked;
        _inputHandler.Fire2Clicked -= _laserWeponController.OnAttackClicked;
        _inputHandler.MoveClicked -= _playerMoveBehavior.Move;
        _inputHandler.RotationClicked -= _playerMoveBehavior.Rotate;
        
        _healthModel.ResourceEnded -= OnPlayerResourceEnded;
        _collisionHandler.OnGameObjectContact -= OnCollision;
    }
    
    private void OnPlayerResourceEnded()
    {
        Dispose();
        PlayerDead?.Invoke();
    }
    
    private void OnCollision(string tag)
    {
        if (tag == "Enemy")
        {
            _healthModel.ChangeResource(-1.0f);
        }
    }
}


