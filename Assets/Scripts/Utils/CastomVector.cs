using UnityEngine;

namespace Utils
{
    public struct CustomVector3
    {
        public static implicit operator CustomVector3(Vector3 vector)
        {
            return new CustomVector3(vector.x, vector.y, vector.z);
        }
        
        public static implicit operator Vector3(CustomVector3 vector)
        {
            return new Vector3(vector.X, vector.Y, vector.Z);
        }
        
        public static implicit operator CustomVector3(Vector2 vector)
        {
            return new CustomVector3(vector.x, vector.y, 0);
        }
        
        public static implicit operator Vector2(CustomVector3 vector)
        {
            return new Vector2(vector.X, vector.Y);
        }
        
        public readonly float X;
        public readonly float Y;
        public readonly float Z;

        public CustomVector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }

    
    public struct CustomTransform
    {
        public static implicit operator CustomTransform(Transform transform)
        {
            return new CustomTransform(transform);
        }
        
        public readonly CustomVector3 Rotation;
        public readonly CustomVector3 Position;

        private CustomTransform(Transform transform)
        {               
            Rotation = transform.rotation.eulerAngles;
            Position = transform.position;
        }
    }
}