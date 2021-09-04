using System;
using System.Collections;
using Asteroids.Abstraction;
using Asteroids.View;
using UnityEngine;

namespace Asteroids.Core
{
    public class Bullet : BaseShell
    {
        [SerializeField] private LevelObjectView _view;
        
        private Rigidbody2D _rigidbody;
        public override event Action<BaseShell> ShellDestroyed;
        
        private void Awake()
        {
            _rigidbody = gameObject.GetComponent<Rigidbody2D>();
            _view.OnGameObjectContact += Damage;
        }
        
        public override void Fire(Vector2 direction)
        {
            _rigidbody.AddForce(direction * 10, ForceMode2D.Impulse); 
            
            StartCoroutine(DestroyBullet());
        }

        public override GameObject GetGameObject()
        {
            return gameObject;
        }

        private void Damage(GameObject obj)
        {
            if (obj.CompareTag("Enemy"))
            {
                DestroyShell(); 
            }
        }
        
        private IEnumerator DestroyBullet()
        {
            yield return new WaitForSeconds(2.0f);
            DestroyShell();
        }

        private void DestroyShell()
        {
            ShellDestroyed?.Invoke(this);
        }
    } 
}

