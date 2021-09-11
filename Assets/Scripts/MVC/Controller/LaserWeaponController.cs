using Asteroids.Abstraction;

namespace Asteroids.Controller
{
    public class LaserWeaponController : WeaponController
    {
        public LaserWeaponController(IWeaponSystem weaponSystem, IWeapon weapon, IShellInfo shellInfo, ILevelManager levelManager) : base(weaponSystem, weapon, shellInfo, levelManager)
        {
        }
    }
}