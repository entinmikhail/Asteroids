using System;
using System.Collections.Generic;
using Asteroids.Abstraction;
using UnityEngine;

namespace Asteroids.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Gameplay/LevelInfo", fileName = "LevelInfo")]
    public class LevelInfo : ScriptableObject, ISerializationCallbackReceiver, ILevelInfo
    {
        public Bounds LevelBounds => _levelBounds;
        public int UfosOnStart => _ufosOnStart;
        public int AsteroidsOnStart => _asteroidsOnStart;
        public int MiniAsteroidsPerAsteroid => _miniAsteroidsPerAsteroid;
        public Vector3 DefaultPlayerPosition  => _defaultPlayerPosition;
        public Quaternion DefaultPlayerRotation  => _defaultPlayerRotation;

        [SerializeField] private Bounds _levelBounds;
        [SerializeField] private int _ufosOnStart;
        [SerializeField] private Vector3 _defaultPlayerPosition;
        [SerializeField] private Quaternion _defaultPlayerRotation;
        [SerializeField] private int _asteroidsOnStart;
        [SerializeField] private int _miniAsteroidsPerAsteroid;

        [SerializeField] private ObjectsInfos _weaponInfos;
        [SerializeField] private List<IdsInfos<GameObject>> _levelObjectInfos;
        [SerializeField] private List<IdsInfos<EnemyInfo>> _enemyInfos;
        [SerializeField] private List<IdsInfos<ShellInfo>> _shellInfos;

        [SerializeField] private PlayerInfo _playerInfo;

        private IDictionary<string, GameObject> _levelObjectInfosDict;
        private IDictionary<string, EnemyInfo> _enemyInfosDict;
        private IDictionary<string, ShellInfo> _shellInfosDict;

        public GameObject GetLevelObjectPrefab(string id) => _levelObjectInfosDict[id];
        public IPlayerInfo GetPlayerInfo() => _playerInfo;

        public IWeaponInfo GetWeaponInfo(LevelObjectType type) => _weaponInfos.GetInfo(type);
        public IEnemyInfo GetEnemyInfo(string id) => _enemyInfosDict[id];
        public IShellInfo GetShellInfo(string id) => _shellInfosDict[id];

        public void OnAfterDeserialize()
        {
            if(_levelObjectInfos == null) return;

            _levelObjectInfosDict = new Dictionary<string, GameObject>(_levelObjectInfos.Capacity);
            foreach (var levelObject in _levelObjectInfos)
            {
                _levelObjectInfosDict[levelObject.Id] = levelObject.Info;
            }
            
            if(_enemyInfos == null) return;
           
            _enemyInfosDict = new Dictionary<string, EnemyInfo>(_enemyInfos.Capacity);
            foreach (var enemyInfo in _enemyInfos)
            {
                _enemyInfosDict[enemyInfo.Id] = enemyInfo.Info;
            }
            
            if(_shellInfos == null) return;
           
            _shellInfosDict = new Dictionary<string, ShellInfo>(_enemyInfos.Capacity);
            foreach (var shellInfo in _shellInfos)
            {
                _shellInfosDict[shellInfo.Id] = shellInfo.Info;
            }
        }
        
        public void OnBeforeSerialize()
        {
        }
    }

    [Serializable]
    public struct IdsInfos<T>
    {
        public string Id;
        public T Info;
    }
}