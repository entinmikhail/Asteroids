using System;
using Asteroids.Abstraction;
using Asteroids.Model;


public class GameModel : IGameModel
{
    private int _countOfSwitches;
    private ViewMode _curViewMode = ViewMode.Sprite;
    public event Action GameRestarted;
    public event Action GameEnded;
    public event Action<ViewMode> ViewModeChanged;
    
    public  ViewMode CurViewMode  => _curViewMode;

    public void RestartGame()
    {
        GameRestarted?.Invoke();
    }

    public void EndGame()
    {
        GameEnded?.Invoke();
    }
    
    public void ChangeViewMode()
    {
        SetViewMode();
        ViewModeChanged?.Invoke(_curViewMode);
    }

    
    private void SetViewMode()
    {
        _countOfSwitches++;
        switch (_countOfSwitches % ProjConstants.CountOfViews)
        {
            case 0:
                _curViewMode = ViewMode.Sprite;
                break;
            case 1:
                _curViewMode = ViewMode.Poligone;
                break;
        }
    }
}


