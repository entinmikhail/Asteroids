using UnityEngine;

namespace Asteroids.Abstraction
{
    public interface ILevelInfo
    {
        Bounds LevelBounds  { get; }
        int UfosOnStart  { get; }
        int AsteroidsOnStart  { get; }
        int MiniAsteroidsPerAsteroid  { get; }
        
        GameObject GetLevelObjectPrefab(string id);
        
        IWeaponInfo GetWeaponInfo(LevelObjectType type);
        IEnemyInfo GetEnemyInfo(string id);
    }
}