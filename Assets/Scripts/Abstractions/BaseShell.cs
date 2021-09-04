using System;
using UnityEngine;

namespace Asteroids.Abstraction
{
    public abstract class BaseShell : MonoBehaviour

    {
        public abstract event Action<BaseShell> ShellDestroyed;
        
        public abstract void Fire(Vector2 direction);

        public abstract GameObject GetGameObject();
    }
}