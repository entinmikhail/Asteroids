using System;

namespace Asteroids.Abstraction
{
    public interface IShell : IModel<IShellInfo>
    {
        event Action<IShell> ShellDestroyed;
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