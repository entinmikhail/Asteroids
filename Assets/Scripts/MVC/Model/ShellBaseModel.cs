using System;
using Asteroids.Abstraction;

namespace Asteroids.Model
{
    public class ShellBaseModel : ModelBase<IShellInfo>, IShell
    {
        public readonly LifeTimeModel LifeTimeModel;
        
        private readonly IShellInfo _shellInfo;
        
        public event Action<IShell> ShellDestroyed;

        public IShellInfo GetInfo() => _shellInfo;
        public ILifeTimeModel GetLifeTimeModel() => LifeTimeModel;

        protected ShellBaseModel(IShellInfo shellInfo): base(shellInfo)
        {
            _shellInfo = shellInfo;
            LifeTimeModel = new LifeTimeModel(_shellInfo);
            LifeTimeModel.LifeTimeEnded += DestroyShell;
        }

        public void DestroyShell()
        {
            LifeTimeModel.LifeTimeEnded -= DestroyShell;

            ShellDestroyed?.Invoke(this);
        }
    }
}