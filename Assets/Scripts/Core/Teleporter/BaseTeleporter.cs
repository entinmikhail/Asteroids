using System.Collections;
using UnityEngine;

namespace Asteroids.Core.Teleporter
{
    public abstract class BaseTeleporter : MonoBehaviour
    {
        protected Vector2 _teleportDirection;
        protected Vector3 _teleportIndent;
        

        private void OnTriggerEnter2D(Collider2D other)
        {
            
            other.transform.SetPositionAndRotation((other.transform.position + GetTeleportIndent(other))  * _teleportDirection,
                other.transform.rotation);
        }

        protected virtual Vector3 GetTeleportIndent(Collider2D other)
        {
            return new Vector3();
        }
    }
}