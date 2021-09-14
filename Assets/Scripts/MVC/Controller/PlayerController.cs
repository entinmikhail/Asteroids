using Asteroids.Abstraction;
using Asteroids.Model;
using Asteroids.View;
using ModestTree;
using UnityEngine;
using Utils;


namespace Asteroids.Controller
{
    public class PlayerController : ControllerBase, IUpdatable
    {
        private readonly IPlayer _playerModel;
        private readonly IInputHandler _inputHandler;
        private readonly ILevelManager _levelManager;
        
        private IPlayerView _playerView;
    
        private IPlayerMoveBehavior _playerMoveBehavior;
        private readonly BulletWeaponController _bulletWeaponController;
        private readonly LaserWeaponController _laserWeaponController;
        
        private IWeapon _bulletWeapon;
        private IWeapon _laserWeapon;
        private IPlayerInfo _playerInfo;

        public PlayerController(IPlayer playerModel, IInputHandler inputHandler, ILevelManager levelManager)
        {
            _playerModel = playerModel;
            _inputHandler = inputHandler;
            _levelManager = levelManager;
            
            var levelInfo = _levelManager.GetCurrentLevel().GetInfo();
            
            _bulletWeapon = new WeaponModel(levelInfo.GetWeaponInfo(LevelObjectType.Bullet));
            _laserWeapon = new WeaponModel(levelInfo.GetWeaponInfo(LevelObjectType.Laser));
            
            _bulletWeaponController = new BulletWeaponController(_bulletWeapon, levelInfo.GetShellInfo(ProjConstants.Bullet),_levelManager);
            _laserWeaponController = new LaserWeaponController( _laserWeapon, levelInfo.GetShellInfo(ProjConstants.Laser), _levelManager);
        }
    
        protected override void OnStart()
        {
            var levelInfo = _levelManager.GetCurrentLevel().GetInfo();
            _playerInfo = levelInfo.GetPlayerInfo();

            _playerModel.GetResource(ProjConstants.HealthId).SetResourceValue(_playerInfo.Health);

            _playerView = _levelManager.CreateObjectView<IPlayerView>( _playerModel, CustomVector3.zero);

            _playerMoveBehavior = _playerInfo.CreatePlayerMoveBehavior(_playerModel.IsCurView3d);
            
            _playerMoveBehavior.Init(_playerView, _playerView, _playerInfo, levelInfo);

            _bulletWeaponController.Start();
            _laserWeaponController.Start();
            Attach();
        }

        public void OnChange(IPlayerView playerView)
        {
            
            var levelInfo = _levelManager.GetCurrentLevel().GetInfo();
            
            _playerView = playerView;

            _playerMoveBehavior = _playerInfo.CreatePlayerMoveBehavior(!_playerModel.IsCurView3d);
            
            _playerMoveBehavior.Init(playerView, playerView, _playerInfo, levelInfo);
        }
        
        public void Update(double deltaTime)
        { 
            _bulletWeaponController.Update(deltaTime);
            _laserWeaponController.Update(deltaTime);
            
            
        }
    
        private void OnPlayerContact(ILevelObjectView self, ILevelObjectView contact)
        {
            if (contact.Tag == ProjConstants.Enemy)
            {
                _playerModel.GetResource(ProjConstants.HealthId).ChangeResource(-1.0f);
            }
        }

        private void OnPlayerResourceEnded(IModel<IPlayerInfo> model)
        {
            Dispose();
        }
        
        private void OnBulletFireClicked()
        {
            _bulletWeapon.ProduceFire();
        }    
        
        private void OnLaserFireClicked()
        {
            
            _laserWeapon.ProduceFire();
        }
        
        private void OnRotate(float value)
        {
            _playerMoveBehavior.Rotate(value);
            _playerModel.SetTransform(_playerView.Transform);
        }

        private void OnMove(float value)
        {
            _playerMoveBehavior.Move(value);
            _playerModel.SetTransform(_playerView.Transform);
        }
        
        private void Attach()
        {
            _inputHandler.Fire1Clicked += OnBulletFireClicked;
            _inputHandler.Fire2Clicked += OnLaserFireClicked;
            _inputHandler.MoveClicked += OnMove;
            _inputHandler.RotationClicked += OnRotate;
        
            _playerModel.HealthEnded += OnPlayerResourceEnded;
            _playerView.OnLevelObjectContact += OnPlayerContact;
        }
        private void Detach()
        {
            _inputHandler.Fire1Clicked -= OnBulletFireClicked;
            _inputHandler.Fire2Clicked -= OnLaserFireClicked;
            _inputHandler.MoveClicked -= OnMove;
            _inputHandler.RotationClicked -= OnRotate;
        
            _playerModel.HealthEnded  -= OnPlayerResourceEnded;
            _playerView.OnLevelObjectContact -= OnPlayerContact;
        }
    
        protected override void OnDispose()
        {
            Detach();
        
            _bulletWeaponController.Dispose();
            _laserWeaponController.Dispose();
        
           _levelManager.DestroyView(_playerModel);
           _levelManager.DestroyBehaviour((BaseBehavior)_playerMoveBehavior);
        }
    }
}


