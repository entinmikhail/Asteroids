using System;
using Asteroids.Abstraction;
using Asteroids.ScriptableObjects;
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

        public LevelObjectType LevelObjectType => levelObjectType;
        [SerializeField] private LevelObjectType levelObjectType;
        
        public event Action<ILevelObjectView, ILevelObjectView> OnLevelObjectContact;
        public event Action<GameObject> OnGameObjectContact;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject == null)
                return;
            
            if (collision.gameObject.TryGetComponent<LevelObjectView>(out var objView))
            {
                OnLevelObjectContact?.Invoke(this, objView);
            }

            OnGameObjectContact?.Invoke(collision.gameObject);
        }
    }
}