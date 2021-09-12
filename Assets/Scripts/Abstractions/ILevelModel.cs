using System;
using System.Collections.Generic;

namespace Asteroids.Abstraction
{
    public interface ILevelModel
    {
        IList<IEnemy> CurrentEnemies { get; }
        IPlayer CurrentPlayer { get; }
        
        event Action<IEnemy> EnemyAdded; 
        event Action<IEnemy> EnemyRemoved;
        event Action<IShell> ShellAdded; 
        event Action<IShell> ShellRemoved;

        ILevelInfo GetInfo();

        void StartLevel();
        void ClearLevel();
        void SpawnTypedEnemy(params object[] buildParams);
        void SpawnTypedShell(params object[] buildParams);
    }
}