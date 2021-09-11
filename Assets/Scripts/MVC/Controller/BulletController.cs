using Asteroids.Abstraction;

namespace Asteroids.Controller
{
    public class BulletController : ShellControllerBase
    {
        public BulletController(IShell shell, ILevelManager levelManager) : base(shell, levelManager)
        {
        }

        protected override void InitBehaviour()
        {
            _shellBehavior.Init(_view, _playerView, _shellInfo);
        }
    }
}