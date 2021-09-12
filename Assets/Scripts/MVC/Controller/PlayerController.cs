using Asteroids.Abstraction;
using Asteroids.Model;
using Asteroids.System;
using UnityEngine;

namespace Asteroids.Controller
{
    public class PlayerController : ControllerBase, IUpdatable
    {
        private readonly IPlayer _playerModel;
        private readonly IInputHandler _inputHandler;
        private readonly ILevelManager _levelManager;

        private IPlayerView _playerView;
    
        private IPlayerMoveBehavior _playerMoveBehavior;
        private BulletWeaponController _bulletWeaponController;
        private LaserWeaponController _laserWeaponController;
    
        private WeaponSystem _weaponSystem;
        private WeaponModel _weaponModel;
        private IPlayerInfo _playerInfo;

        public PlayerController(IPlayer playerModel, IInputHandler inputHandler, ILevelManager levelManager)
        {
            _playerModel = playerModel;
            _inputHandler = inputHandler;
            _levelManager = levelManager;
        }
    
        protected override void OnStart()
        {
            var levelInfo = _levelManager.GetCurrentLevel().GetInfo();
            _playerInfo = levelInfo.GetPlayerInfo();
        
            _playerModel.GetResource(ProjConstants.HealthId).SetResourceValue(_playerInfo.Health);

            _playerView = _levelManager.CreateObjectView<IPlayerView>(ProjConstants.Player, _playerModel, Vector3.zero); 
            _playerView.Transform.position = levelInfo.DefaultPlayerPosition;
            _playerView.Transform.rotation = levelInfo.DefaultPlayerRotation;
        
            _weaponSystem = new WeaponSystem();

            _playerMoveBehavior = _playerInfo.PlayerMoveBehavior;
            _playerMoveBehavior.Init(_playerView, _playerInfo);
         
            _bulletWeaponController = new BulletWeaponController(_weaponSystem, new WeaponModel(levelInfo.GetWeaponInfo(LevelObjectType.Bullet)), levelInfo.GetShellInfo(ProjConstants.Bullet),_levelManager);
            _laserWeaponController = new LaserWeaponController(_weaponSystem, new WeaponModel(levelInfo.GetWeaponInfo(LevelObjectType.Laser)), levelInfo.GetShellInfo(ProjConstants.Laser), _levelManager);

            Attach();
        }

        public void Update(double deltaTime)
        { 
            _weaponSystem.Update(deltaTime);
        }
    
        private void OnPlayerContact(ILevelObjectView self, ILevelObjectView contact)
        {
            if (contact.Tag == ProjConstants.Enemy)
            {
                _playerModel.GetResource(ProjConstants.HealthId).ChangeResource(-1.0f);
            }
        }

        private void OnPlayerResourceEnded(IModel model)
        {
            Dispose();
        }
    
        private void Attach()
        {
            _inputHandler.Fire1Clicked += _bulletWeaponController.OnAttackClicked;
            _inputHandler.Fire2Clicked += _laserWeaponController.OnAttackClicked;
            _inputHandler.MoveClicked += _playerMoveBehavior.Move;
            _inputHandler.RotationClicked += _playerMoveBehavior.Rotate;
        
            _playerModel.HealthEnded += OnPlayerResourceEnded;
        
            _playerView.OnLevelObjectContact += OnPlayerContact;
        }

        private void Detach()
        {
            _inputHandler.Fire1Clicked -= _bulletWeaponController.OnAttackClicked;
            _inputHandler.Fire2Clicked -= _laserWeaponController.OnAttackClicked;
            _inputHandler.MoveClicked -= _playerMoveBehavior.Move;
            _inputHandler.RotationClicked -= _playerMoveBehavior.Rotate;
        
            _playerModel.HealthEnded  -= OnPlayerResourceEnded;
            _playerView.OnLevelObjectContact -= OnPlayerContact;
        }
    
        protected override void OnDispose()
        {
            Detach();
        
            _bulletWeaponController.Dispose();
            _laserWeaponController.Dispose();
        
           _levelManager.DestroyView(_playerModel, _playerView);
        }
    }
}


