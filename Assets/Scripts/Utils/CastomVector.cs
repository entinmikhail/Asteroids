using UnityEngine;

namespace Utils
{
    public struct CastomVector3
    {
        public readonly float X;
        public readonly float Y;
        public readonly float Z;

        public CastomVector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        
        public CastomVector3(Vector3 vector3)
        {
            X = vector3.x;
            Y = vector3.y;
            Z = vector3.z;
        }
        
        public CastomVector3(Vector2 vector2)
        {
            X = vector2.x;
            Y = vector2.y;
            Z = 0;
        }

        public Vector3 ToVector3()
        {
            return new Vector3(X, Y, Z);
        }
       
    }

    public struct CastomTransform
    {
        public readonly CastomVector3 Rotation;
        public readonly CastomVector3 Position;

        public CastomTransform(Transform transform)
        {
            Rotation = new CastomVector3(transform.rotation.ToEulerAngles());
            Position = new CastomVector3(transform.position);
        }
    }
}