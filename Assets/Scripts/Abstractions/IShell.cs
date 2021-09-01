using System;
using UnityEngine;

namespace Asteroids.Abstraction
{
    public interface IShell
    {
        public event Action<BaseShell> ShellDesroyed;
        public void Fire(Vector2 direction);
        public GameObject GetGameObject();
    }
}