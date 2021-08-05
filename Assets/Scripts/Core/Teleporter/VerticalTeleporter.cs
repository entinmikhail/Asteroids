using UnityEngine;

namespace Asteroids.Core.Teleporter
{
    public class VerticalTeleporter : BaseTeleporter
    {
        VerticalTeleporter()
        {
            _teleportDirection = new Vector2(1, -1);
            _teleportIndent = new Vector3(0, 1);
        }

        protected override Vector3 GetTeleportIndent(Collider2D other)
        {
            return other.transform.position.y < 0 ? _teleportIndent : -_teleportIndent;
        }
    }   
}
