using System;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids.Abstraction
{
    public interface ILevelManager
    {
        ILevelModel GetCurrentLevel();
        T GetObjectView<T>(string id, Vector3 position) where T : ILevelObjectView;
        IPlayerView GetPlayerView();
        void SetLevel(ILevelModel levelModel);
    }
    
    public interface ILevelModel
    {
        IList<IEnemy> CurrentEnemies { get; }
        
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