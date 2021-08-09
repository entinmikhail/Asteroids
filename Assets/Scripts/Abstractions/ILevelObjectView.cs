using System;
using UnityEngine;

namespace Asteroids.Abstraction
{
    public interface ILevelObjectView 
    {
        Transform Transform { get; }
        
        Rigidbody2D Rigidbody2D { get; }
        
        Collider2D Collider2D { get; }
        
        event Action<ILevelObjectView, ILevelObjectView> OnLevelObjectContact;
    }
}



