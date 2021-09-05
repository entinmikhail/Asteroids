using System;
using System.Collections.Generic;
using Asteroids.Abstraction;
using UnityEngine;

namespace Asteroids.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Gameplay/ObjectsInfos", fileName = "ObjectsInfos")]
    public class ObjectsInfos : ScriptableObject, ISerializationCallbackReceiver
    {
        public IWeaponInfo GetInfo(LevelObjectType objectType) => _infosDict[objectType];
        
        [SerializeField] private List<ObjectInfo> _objectInfos;
        private IDictionary<LevelObjectType, IWeaponInfo> _infosDict;

        public void OnAfterDeserialize()
        {
            if(_objectInfos == null) return;

            _infosDict = new Dictionary<LevelObjectType, IWeaponInfo>(_objectInfos.Capacity);
            foreach (var info in _objectInfos)
            {
                _infosDict[info.LevelObjectType] = info.WeaponInfo;
            }
        }
        
        public void OnBeforeSerialize()
        {
        }

    }

    [Serializable]
    public sealed class ObjectInfo 
    {
        public LevelObjectType LevelObjectType;
        public WeaponInfo WeaponInfo;
    }
}