using System;

namespace Asteroids.Abstraction
{
    public interface IGameModel
    {
        event Action GameRestarted;
        event Action GameEnded;
        event Action<ViewMode> ViewModeChanged;
        ViewMode CurViewMode { get; }
        void RestartGame();
        void EndGame();
        void ChangeViewMode();
    }
}