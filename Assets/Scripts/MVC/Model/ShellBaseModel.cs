using System;
using Asteroids.Abstraction;

namespace Asteroids.Model
{
    public class ShellBaseModel : IShell

    {
        public readonly LifeTimeModel LifeTimeModel;
        
        private readonly IShellInfo _shellInfo;
        
        public event Action<IShell> ShellDestroyed;

        public IShellInfo GetInfo() => _shellInfo;
        public ILifeTimeModel GetLifeTimeModel() => LifeTimeModel;
        
        public ShellBaseModel(IShellInfo shellInfo)
        {
            _shellInfo = shellInfo;
            LifeTimeModel = new LifeTimeModel(_shellInfo);
            LifeTimeModel.LifeTimeEnded += DestroyShell;
        }

        public void DestroyShell()
        {
            ShellDestroyed?.Invoke(this);
            LifeTimeModel.LifeTimeEnded -= DestroyShell;
        }
    }
}