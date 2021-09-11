using System;
using Asteroids.Abstraction;

namespace Asteroids.Model
{
    public class LifeTimeModel : ILifeTimeModel

    {
    private IShellInfo _shellInfo;

    private double _curLifeTime;

    public LifeTimeModel(IShellInfo shellInfo)
    {
        _shellInfo = shellInfo;
    }

    public event Action LifeTimeEnded;

    public double GetLifeTime() => _curLifeTime;

    public void SetLifeTime(double deltaTime)
    {
        _curLifeTime += deltaTime;

        if (_curLifeTime > _shellInfo.ShellLifeTime) LifeTimeEnded?.Invoke();
    }
    }
}