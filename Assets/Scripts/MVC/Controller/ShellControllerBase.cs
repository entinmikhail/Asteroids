using Asteroids.Abstraction;
using Asteroids.Model;
using UnityEngine;

namespace Asteroids.Controller
{
    public abstract class ShellControllerBase : IShellController, IUpdatable

    {
        protected ILevelObjectView _view;
        
        private ILevelManager _levelManager;
        protected BaseShellBehavior _shellBehavior;
        private ShellBaseModel _shellBaseModel;
        protected readonly IShellInfo _shellInfo;
        protected IPlayerView _playerView;
        private readonly IShell _shell;

        private bool _inited;
        
        protected ShellControllerBase(IShell shell, ILevelManager levelManager)
        {
            _shell = shell;
            _shellInfo = shell.GetInfo();
            _levelManager = levelManager;
        }

        public void Start()
        {
            if (_inited) return;
            _inited = true;

            _shellBehavior = _shellInfo.ShellBehavior;
            _playerView = _levelManager.GetPlayerView();
            _view = _levelManager.GetObjectView<ILevelObjectView>(_shellInfo.ViewId, _playerView.SpawnPoint.position);
            
            _view.OnLevelObjectContact += OnCollision;
            _shell.ShellDestroyed += OnShellDestroyed;
            InitBehaviour();
        }
        

        private void OnCollision(ILevelObjectView selfObject, ILevelObjectView contactObject)
        {
            if (_shellInfo.Destroyable && contactObject.Transform.gameObject.CompareTag("Enemy")) // 
            {
                _shell.DestroyShell();
            }
        }
        
        protected abstract void InitBehaviour();

        public void Update(double deltaTime)
        {
           _shell.GetLifeTimeModel().SetLifeTime(deltaTime);
            
           _shellBehavior.OnUpdate(_view, _playerView, _shellInfo.MovementSpeed);
        }

        private void OnShellDestroyed(IShell obj)
        {
            Dispose();
        }
        
        public void Dispose()
        {
            if (!_inited) return;
            _inited = false;
            
            _view.OnLevelObjectContact -= OnCollision;
            _shell.ShellDestroyed -= OnShellDestroyed;
            Object.Destroy(_view.Transform.gameObject); //
        }
    }
}