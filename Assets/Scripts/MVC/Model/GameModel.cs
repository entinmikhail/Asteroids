using System;

public class GameModel
{
    public event Action GameRestarted;
    public event Action GameEnded;
    
    public void RestartGame()
    {
        GameRestarted?.Invoke();
    }

    public void EndGame()
    {
        GameEnded?.Invoke();
    }
}
