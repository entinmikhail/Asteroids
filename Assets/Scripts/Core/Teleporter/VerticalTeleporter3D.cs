using UnityEngine;

namespace Asteroids.Core.Teleporter
{
    public class VerticalTeleporter3D : BaseTeleporter3D
    {
        private void Awake()
        {
            _teleportDirection = new Vector2(1, -1);
            _teleportIndent = new Vector3(0, 1, 0);
        }

        protected override Vector3 GetTeleportPosition(Collider other)
        {
            return other.transform.position.y < 0 ? _teleportIndent : -_teleportIndent;
        }
    }
}