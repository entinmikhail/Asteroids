using System;

namespace Asteroids.Abstraction
{
    public interface IController : IDisposable
    {
        void Start();
        void ResetView();
    }
}