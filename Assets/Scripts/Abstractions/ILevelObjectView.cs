using UnityEngine;
using Utils;

namespace Asteroids.Abstraction
{
    public delegate void ContactHandler(ILevelObjectView self, ILevelObjectView contact);
    
    public interface ILevelObjectView 
    {
        CustomTransform Transform { get; }
        LevelObjectType LevelObjectType { get; }
        string Tag { get; }
        event ContactHandler OnLevelObjectContact;
    }

    public interface ILevelObjectViewUnity 
    {
        Transform UnityTransform { get; }
    }
    
    public interface ILevelObjectViewUnity3D : ILevelObjectViewUnity
    {
        Rigidbody Rigidbody { get; }
    }
    public interface ILevelObjectViewUnity2D : ILevelObjectViewUnity
    {
        Rigidbody2D Rigidbody2D { get; }
    }

    public interface IPlayerViewUnity2D : ILevelObjectViewUnity2D
    {
        Transform SpawnPoint { get; }
    } 
    
    public interface IPlayerViewUnity3D : ILevelObjectViewUnity3D
    {
        Transform SpawnPoint { get; }
    }
}



