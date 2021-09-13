using Asteroids.Abstraction;

namespace Asteroids.Controller
{
    public class LaserWeaponController : WeaponController
    {
        public LaserWeaponController( IWeapon weapon, IShellInfo shellInfo, ILevelManager levelManager) : base( weapon, shellInfo, levelManager)
        {
        }
    }
}