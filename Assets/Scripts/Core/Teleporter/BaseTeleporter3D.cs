using UnityEngine;

namespace Asteroids.Core.Teleporter
{
    public abstract class BaseTeleporter3D : MonoBehaviour
    {
        [SerializeField] protected Vector2 _teleportDirection;
        [SerializeField] protected Vector3 _teleportIndent;
        
        private void OnTriggerEnter(Collider other)
        {
            
            if (other.transform == null)
                return;
            
            other.transform.SetPositionAndRotation((other.transform.position + 
                                                    GetTeleportPosition(other)) * _teleportDirection,
                other.transform.rotation);
        }
        
        protected abstract Vector3 GetTeleportPosition(Collider other);
    }
}