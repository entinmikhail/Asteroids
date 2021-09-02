using System;
using UnityEngine;

namespace Asteroids.Abstraction
{
    public interface IShell
    {
        public event Action<BaseShell> ShellDestroyed;
        public void Fire(Vector2 direction);
        public GameObject GetGameObject();
    }
}