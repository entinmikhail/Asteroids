using System;
using Asteroids.Abstraction;

namespace Asteroids.Model
{
    public class ShellBaseModel : IShell

    {
        private readonly IShellInfo _shellInfo;

        private float _maxSpeed;

        public event Action<IShell> ShellDestroyed;

        public IShellInfo GetInfo() => _shellInfo;
        
        public ShellBaseModel(IShellInfo shellInfo)
        {
            _shellInfo = shellInfo;
        }

        public void DestroyShell()
        {
            ShellDestroyed?.Invoke(this);
        }
    }
}