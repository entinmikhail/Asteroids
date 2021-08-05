using System.Collections;
using UnityEngine;

namespace Asteroids.Core
{
    public class Bullet : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        private void Awake()
        {
            _rigidbody = gameObject.GetComponent<Rigidbody2D>();
        }
        
        public void Fire(Vector2 direction)
        {
            _rigidbody.AddForce(direction * 10, ForceMode2D.Impulse); 
            
            StartCoroutine(DestroyBullet());
        }
        

        private IEnumerator DestroyBullet()
        {
            yield return new WaitForSeconds(5.0f);
            Destroy(gameObject);
        }
    } 
}

