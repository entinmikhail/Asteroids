using Asteroids.Abstraction;

namespace Asteroids.Controller
{
    public class WeaponController : ControllerBase, IWeaponController, IUpdatable 
    {
        private readonly IWeapon _weapon;

        private readonly IShellInfo _shellInfo;
        private readonly ILevelManager _levelManager;

        protected WeaponController( IWeapon weapon, IShellInfo shellInfo, ILevelManager levelManager)
        {
            _weapon = weapon;
            _shellInfo = shellInfo;
            _levelManager = levelManager;
        }
        
        protected override void OnStart()
        {
            _weapon.Shot += OnWeaponShot;
        }
        
        public void Update(double deltaTime)
        {
            if (!_started) return;

            _weapon.Update(deltaTime);
        }
        
        private void OnWeaponShot()
        {
            _levelManager.GetCurrentLevel().SpawnTypedShell(_shellInfo);
        }

        protected override void OnViewReset() { }

        protected override void OnDispose()
        {
            _weapon.Shot -= OnWeaponShot;
        }
    }
}