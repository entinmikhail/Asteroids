using Asteroids.Abstraction;
using Asteroids.Model;

namespace Asteroids.Controller
{
    public class BulletController : ShellControllerBase
    {
        public BulletController(IShell shell, ILevelManager levelManager) : base(shell, levelManager)
        {
        }

        protected override void InitBehaviour()
        {
            _shellBehavior.Init(View, _playerView, _shellInfo);
        }
    }
}