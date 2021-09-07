using System;

namespace Asteroids.Abstraction
{
    public interface IInputHandler
    {
        event Action Fire1Clicked;
        event Action Fire2Clicked;
        event Action<float> MoveClicked;
        event Action<float> RotationClicked;
    }
}