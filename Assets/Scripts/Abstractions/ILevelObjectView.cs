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
          Transform UnityTransfom { get; }
          Rigidbody2D Rigidbody2D { get; }
    }

    public interface IPlayerViewUnity : ILevelObjectViewUnity

    {
    Transform SpawnPoint { get; }
    }
}



