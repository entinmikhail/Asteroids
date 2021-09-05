using System;
using System.Collections;
using Asteroids.Abstraction;
using UnityEngine;


namespace Asteroids.Core
{
    public class LaserShell : BaseShell
    {
        public override event Action<BaseShell> ShellDestroyed;
        private Rigidbody asd;
        public override void Fire(Vector2 direction)
        {
            
            StartCoroutine(DestroyBullet());
        }

        public override GameObject GetGameObject()
        {
            return gameObject;
        }
        
        private IEnumerator DestroyBullet()
        {
            yield return new WaitForSeconds(0.5f);
            DestroyShell();
        }

        private void DestroyShell()
        {
            ShellDestroyed?.Invoke(this);
        }
    } 
}
