using Asteroids.Abstraction;
using UnityEngine;
using Utils;

namespace Asteroids.View
{
    public class LevelObjectView : MonoBehaviour, ILevelObjectView, ILevelObjectViewUnity
    {
        public CustomTransform Transform => _transform;
        public Rigidbody2D Rigidbody2D => _rigidbody;
        public Transform UnityTransfom => _transform;
        public LevelObjectType LevelObjectType => levelObjectType;
        public string Tag => gameObject.tag;
        
        [SerializeField] private Transform _transform;
        [SerializeField] private LevelObjectType levelObjectType;
        [SerializeField] private Rigidbody2D _rigidbody;
        public event ContactHandler OnLevelObjectContact;
        

        
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