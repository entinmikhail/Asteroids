using System;
using Asteroids.Abstraction;
using UnityEngine;

namespace Asteroids.View
{
    public class LevelObjectView : MonoBehaviour, ILevelObjectView
    {
        public Transform Transform => _transform;
        [SerializeField] private Transform _transform;
        
        public Rigidbody2D Rigidbody2D => _rigidbody;
        [SerializeField] private Rigidbody2D _rigidbody;
        
        public Collider2D Collider2D => _collider;
        [SerializeField] private Collider2D _collider;

        public event Action<ILevelObjectView> OnLevelObjectContact;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            OnLevelObjectContact?.Invoke(collision.gameObject.GetComponent<LevelObjectView>());
        }
    }
}