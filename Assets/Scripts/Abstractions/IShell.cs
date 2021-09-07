using System;

namespace Asteroids.Abstraction
{
    public interface IShell
    {
        public event Action<IShell> ShellDestroyed;
        IShellInfo GetInfo();
        
    }
}