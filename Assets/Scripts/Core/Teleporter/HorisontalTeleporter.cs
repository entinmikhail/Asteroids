using UnityEngine;

namespace Asteroids.Core.Teleporter
{
    public class HorisontalTeleporter : BaseTeleporter
    {
        HorisontalTeleporter()
        {
            _teleportDirection = new Vector2(-1, 1);
            _teleportIndent = new Vector3(1, 0);
        }
        
        protected override Vector3 GetTeleportIndent(Collider2D other)
        {
            return other.transform.position.x < 0 ? _teleportIndent : -_teleportIndent;
        }
    }
}