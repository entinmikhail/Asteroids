using Asteroids.Abstraction;

namespace Asteroids.Controller
{
    public class BulletWeaponController : WeaponController
    {
        public BulletWeaponController(IWeaponSystem weaponSystem, IWeapon weapon, IShellInfo shellInfo, ILevelManager levelManager) : base(weaponSystem, weapon, shellInfo, levelManager)
        {
        }
    }
}