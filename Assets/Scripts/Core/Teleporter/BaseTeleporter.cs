using UnityEngine;

namespace Asteroids.Core.Teleporter
{
    public abstract class BaseTeleporter : MonoBehaviour
    {
        protected Vector2 _teleportDirection;
        protected Vector3 _teleportIndent;
        

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.transform == null)
                return;
            
            other.transform.SetPositionAndRotation((other.transform.position + GetTeleportPosition(other)) 
                                                   * _teleportDirection, other.transform.rotation);
        }
        
        protected abstract Vector3 GetTeleportPosition(Collider2D other);
    }
}