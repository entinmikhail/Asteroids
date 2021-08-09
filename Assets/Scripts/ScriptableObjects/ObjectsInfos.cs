using System;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Gameplay/ObjectsInfos", fileName = "ObjectsInfos")]
    public class ObjectsInfos : ScriptableObject
    {
        public WeaponInfo GetInfo(LevelObjectType objectType)
        {
            return _objectInfos.Find(info => info.LevelObjectType.Equals(objectType)).WeaponInfo;
        }
        
        [SerializeField] private List<ObjectInfo> _objectInfos;
    }

    [Serializable]
    public sealed class ObjectInfo 
    {
        public LevelObjectType LevelObjectType;
        public WeaponInfo WeaponInfo;
    }
}