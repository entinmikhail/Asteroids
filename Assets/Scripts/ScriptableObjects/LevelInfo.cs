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
        
        [SerializeField] private Bounds _levelBounds;
        [SerializeField] private int _ufosOnStart;
        [SerializeField] private int _asteroidsOnStart;
        [SerializeField] private int _miniAsteroidsPerAsteroid;

        [SerializeField] private ObjectsInfos _weaponInfos;
        [SerializeField] private List<LevelObjectInfoSO> _levelObjectInfos;
        [SerializeField] private List<EnemyInfoSO> _enemyInfos;
        private IDictionary<string, GameObject> _levelObjectInfosDict;
        private IDictionary<string, EnemyInfo> _enemyInfosDict;

        public GameObject GetLevelObjectPrefab(string id) => _levelObjectInfosDict[id];
        public IWeaponInfo GetWeaponInfo(LevelObjectType type) => _weaponInfos.GetInfo(type);
        public IEnemyInfo GetEnemyInfo(string id) => _enemyInfosDict[id];
        
        public void OnAfterDeserialize()
        {
            if(_levelObjectInfos == null) return;

            _levelObjectInfosDict = new Dictionary<string, GameObject>(_levelObjectInfos.Capacity);
            foreach (var levelObject in _levelObjectInfos)
            {
                _levelObjectInfosDict[levelObject.Id] = levelObject.Prefab;
            }
            
            if(_enemyInfos == null) return;
           
            _enemyInfosDict = new Dictionary<string, EnemyInfo>(_enemyInfos.Capacity);
            foreach (var enemyInfo in _enemyInfos)
            {
                _enemyInfosDict[enemyInfo.Id] = enemyInfo.Info;
            }
            
        }
        
        public void OnBeforeSerialize()
        {
        }
    }

    [Serializable]
    public struct LevelObjectInfoSO
    {
        public string Id;
        public GameObject Prefab;
    } 
    
    [Serializable]
    public struct EnemyInfoSO
    {
        public string Id;
        public EnemyInfo Info;
    }
}