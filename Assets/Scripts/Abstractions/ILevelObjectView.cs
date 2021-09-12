using UnityEngine;

namespace Asteroids.Abstraction
{
    public delegate void ContactHandler(ILevelObjectView self, ILevelObjectView contact);
    
    public interface ILevelObjectView 
    {
        Transform Transform { get; }
        
        Rigidbody2D Rigidbody2D { get; }
        
        Collider2D Collider2D { get; }
        
        LevelObjectType LevelObjectType { get; }
        string Tag { get; }

        event ContactHandler OnLevelObjectContact;
    }
}



