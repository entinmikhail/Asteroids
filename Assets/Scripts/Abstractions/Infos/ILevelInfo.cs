using UnityEngine;

namespace Asteroids.Abstraction
{
    public interface ILevelInfo
    {
        Bounds LevelBounds  { get; }
        int UfosOnStart  { get; }
        int AsteroidsOnStart  { get; }
        int MiniAsteroidsPerAsteroid  { get; }
        Vector3 DefaultPlayerPosition { get; }
        Quaternion DefaultPlayerRotation { get; }

        GameObject GetLevelObjectPrefab(string id);
        IPlayerInfo GetPlayerInfo();
        IWeaponInfo GetWeaponInfo(LevelObjectType type);
        IEnemyInfo GetEnemyInfo(string id);
        IShellInfo GetShellInfo(string id);
    }
}