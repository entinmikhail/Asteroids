using System;
using Asteroids.Abstraction;
using Asteroids.Controller;
using Asteroids.Core;
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
    private WeaponController _weaponController;
    private WeaponController _laserWeponController;
    private WeaponSystem _weaponSystem;
    private WeaponModel _weaponModel;
    private GameModel _gameModel;
    private PlayerInfo _playerInfo;
    private ILevelManager _levelManager;

    public event Action PlayerDead;
    public PlayerController(PlayerView playerView, HealthModel healthModel, GameModel gameModel, PlayerInfo playerInfo, IInputHandler inputHandler, ILevelManager levelManager)
    {
        _playerView = playerView;
        _healthModel = healthModel;
        _gameModel = gameModel;
        _playerInfo = playerInfo;
        _inputHandler = inputHandler;
        _levelManager = levelManager;
    }

    public void Start()
    {
        /*_healthModel.SetResourceValue(1);*/
        
        /*
        _playerGameObject.SetActive(true);

        _playerGameObject.transform.SetPositionAndRotation(_defaultPlayerPosition, _defaultRotation);
        */
        
        _weaponSystem = new WeaponSystem();

        _playerMoveBehavior = _playerInfo.PlayerMoveBehavior;
        _playerMoveBehavior.Init(_playerView, _playerInfo);
        
        _weaponModel = new WeaponModel(Resources.Load<WeaponInfo>("DefoultWeaponInfo"));
        
        /*_weaponController = new WeaponController(_weaponSystem, _playerView, _weaponModel, 
            Resources.Load<Bullet>("Bullet").GetComponent<BaseShell>(), _gameModel);
        _laserWeponController = new WeaponController(_weaponSystem, _playerView, _weaponModel, 
            Resources.Load<LaserShell>("Laser").GetComponent<BaseShell>(), _gameModel);*/

        Attach();
    }

    public void Update(double deltaTime)
    { 
        _weaponSystem.Update(deltaTime);
    }
    
    private void Attach()
    {
        _inputHandler.Fire1Clicked += NehuyaVebauv;
        // _inputHandler.Fire2Clicked += _laserWeponController.OnAttackClicked;
        _inputHandler.MoveClicked += _playerMoveBehavior.Move;
        _inputHandler.RotationClicked += _playerMoveBehavior.Rotate;
        
        _healthModel.ResourceEnded += OnPlayerResourceEnded;
        _playerView.OnGameObjectContact += OnCollision;
    }

    private void NehuyaVebauv()
    {
        _levelManager.GetCurrentLevel().SpawnTypedShell(Resources.Load<ShellInfo>("ShellInfo/BulletInfo"));
    }
    public void Dispose()
    {
        Detach();
        
        /*_weaponController.Dispose();
        _laserWeponController.Dispose();*/
    }

    private void Detach()
    {
        /*_inputHandler.Fire1Clicked -= _weaponController.OnAttackClicked;
        _inputHandler.Fire2Clicked -= _laserWeponController.OnAttackClicked;*/
        _inputHandler.MoveClicked -= _playerMoveBehavior.Move;
        _inputHandler.RotationClicked -= _playerMoveBehavior.Rotate;
        
        _healthModel.ResourceEnded -= OnPlayerResourceEnded;
        _playerView.OnGameObjectContact -= OnCollision;
    }
    
    private void OnPlayerResourceEnded()
    {
        Dispose();
        PlayerDead?.Invoke();
    }
    
    private void OnCollision(GameObject obj)
    {
        if (obj.CompareTag("Enemy"))
        {
            _healthModel.ChangeResource(-1.0f);
        }
    }

    void IDisposable.Dispose()
    {
        Dispose();
    }
}
