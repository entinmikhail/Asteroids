using System.Collections;
using Asteroids.View;
using UnityEngine;

namespace Asteroids.Core
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private LevelObjectView _view;
        
        private Rigidbody2D _rigidbody;
        private void Awake()
        {
            _rigidbody = gameObject.GetComponent<Rigidbody2D>();
            _view.OnGameObjectContact += Damage;
        }

        private void Damage(GameObject obj)
        {
            /*var a = obj.GetComponent<Asteroid>();
            a.ChangeHealth(-1.0f);*/
            if (obj.CompareTag("Enemy"))
            {
                DestroyShell(); 
            }
        }

        public void Fire(Vector2 direction)
        {
            _rigidbody.AddForce(direction * 10, ForceMode2D.Impulse); 
            
            StartCoroutine(DestroyBullet());
        }
        

        private IEnumerator DestroyBullet()
        {
            yield return new WaitForSeconds(2.0f);
            DestroyShell();
        }

        private void DestroyShell()//
        {
            Destroy(gameObject);
        }
    } 
}

