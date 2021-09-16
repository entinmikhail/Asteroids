using Asteroids.Abstraction;
using UnityEngine;
using Utils;

namespace Asteroids.View
{
    public class LevelObjectView : MonoBehaviour, ILevelObjectView, ILevelObjectViewUnity2D
    {
        public CustomTransform Transform => GetTransform( );
        public Rigidbody2D Rigidbody2D => _rigidbody;
        public Transform UnityTransform => _transform;
        public LevelObjectType LevelObjectType => levelObjectType;
        public string Tag => gameObject.tag;
        
        [SerializeField] private Transform _transform;
        [SerializeField] private LevelObjectType levelObjectType;
        [SerializeField] private Rigidbody2D _rigidbody;
        
        public event ContactHandler OnLevelObjectContact;
        
        
        private CustomTransform GetTransform()
        {
            CustomTransform customTransform = _transform;
            if(_rigidbody != null)
                customTransform.SetVelocity(_rigidbody.velocity);
            
            return customTransform;
        }
        
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject == null) return;
            
            if (collision.gameObject.TryGetComponent<ILevelObjectView>(out var objView))
            {
                OnLevelObjectContact?.Invoke(this, objView);
            }
        }
    }
}