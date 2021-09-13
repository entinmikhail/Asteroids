using Asteroids.Abstraction;

namespace Asteroids.Controller
{
    public class BulletWeaponController : WeaponController
    {
        public BulletWeaponController(IWeapon weapon, IShellInfo shellInfo, ILevelManager levelManager) : base(weapon, shellInfo, levelManager)
        {
        }
    }
}