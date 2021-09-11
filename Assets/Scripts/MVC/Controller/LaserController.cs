using Asteroids.Abstraction;

namespace Asteroids.Controller
{
    public class LaserController : ShellControllerBase
    {
        public LaserController(IShell shell, ILevelManager levelManager) : base(shell, levelManager)
        {

        }

        protected override void InitBehaviour()
        {
            _shellBehavior.Init(_view, _playerView, _shellInfo);
        }
    }
}