using System;

namespace Asteroids.Abstraction
{
    public interface IShell : IModel
    {
        event Action<IShell> ShellDestroyed;
        IShellInfo GetInfo();
        ILifeTimeModel GetLifeTimeModel();
        void DestroyShell();
    }

    public interface ILifeTimeModel
    {
         event Action LifeTimeEnded;
         double GetLifeTime();
         void SetLifeTime(double deltaTime);
    }
}