using Asteroids.Abstraction;

namespace Asteroids.Controller
{
    public class WeaponController : IWeaponController
    {
        private readonly IWeapon _weapon;
        private readonly IWeaponSystem _weaponSystem;
        private IShellInfo _shellInfo;
        private ILevelManager _levelManager;
        private InputHandler _inputHandler;
        
        public WeaponController(IWeaponSystem weaponSystem,  IWeapon weapon, IShellInfo shellInfo, ILevelManager levelManager)
        {
            _weaponSystem = weaponSystem;
            _weapon = weapon;
            _shellInfo = shellInfo;
            _levelManager = levelManager;
            /*inputHandler = inputHandler;*/
            
            if (weapon is IWeapon updWeapon)
            {
                _weaponSystem.Add(updWeapon);
            }
        }
        
        public void OnAttackClicked()
        {
            if (_weapon.IsFireReady())
            {
                _levelManager.GetCurrentLevel().SpawnTypedShell(_shellInfo);
                
                _weapon.ProduceFire();
            }
        }

        public void Dispose()
        {
            _weaponSystem.Remove(_weapon);
        }

        public void Start()
        {
            
        }
    }
}