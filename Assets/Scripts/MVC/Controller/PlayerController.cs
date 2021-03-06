using Asteroids.Abstraction;
using Asteroids.Model;


namespace Asteroids.Controller
{
    public class PlayerController : ControllerBase, IUpdatable
    {
        private readonly IPlayer _playerModel;
        private readonly IInputHandler _inputHandler;
        private readonly ILevelManager _levelManager;
        private readonly BulletWeaponController _bulletWeaponController;
        private readonly LaserWeaponController _laserWeaponController;

        private readonly IGameModel _gameModel;
        private readonly IWeapon _bulletWeapon;
        private readonly IWeapon _laserWeapon;
        
        private IPlayerView _playerView;
        private IPlayerMoveBehavior _playerMoveBehavior;
        private IPlayerInfo _playerInfo;
        private bool _viewReady;

        public PlayerController(IPlayer playerModel, IInputHandler inputHandler, ILevelManager levelManager)
        {
            _playerModel = playerModel;
            _inputHandler = inputHandler;
            _levelManager = levelManager;
            
            var levelInfo = _levelManager.GetCurrentLevel().GetInfo();
            _gameModel = _levelManager.GetCurrentLevel().GameModel;
            
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
            
            _playerMoveBehavior = (IPlayerMoveBehavior) _levelManager.CreateBehavior(_gameModel.CurViewMode, _playerModel);
            _playerView = _levelManager.CreateObjectView<IPlayerView>(_playerModel);
            
            _playerMoveBehavior.Init(_playerView, _playerView, _playerInfo, levelInfo);
            _viewReady = true;
            _bulletWeaponController.Start();
            _laserWeaponController.Start();
            Attach();
        }
        
        protected override void OnViewReset()
        {
            _playerView.OnLevelObjectContact -= OnPlayerContact;
            _viewReady = false;
            _levelManager.DestroyBehaviour((BaseBehavior)_playerMoveBehavior);
            _playerView = _levelManager.ChangeView<IPlayerView>(_playerModel);
            
            _playerMoveBehavior = (IPlayerMoveBehavior) _levelManager.CreateBehavior(_gameModel.CurViewMode, _playerModel);
            _playerMoveBehavior.Init(_playerView, _playerView, _playerInfo, _levelManager.GetCurrentLevel().GetInfo());
            _viewReady = true;
            _playerView.OnLevelObjectContact += OnPlayerContact;
        }

        public void Update(double deltaTime)
        { 
            if(!_viewReady) return;

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
            if(!_viewReady) return;
            
            _playerMoveBehavior.Rotate(value);
            _playerModel.SetTransform(_playerView.Transform);
        }

        private void OnMove(float value)
        {
            if(!_viewReady) return;

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


