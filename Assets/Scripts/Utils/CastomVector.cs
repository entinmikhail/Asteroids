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
        
        public static CustomVector3 zero = new CustomVector3(0.0f,0.0f,0.0f);

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
        
        public readonly CustomVector3 rotation;
        public readonly CustomVector3 position;
        public readonly CustomVector3 velocity => _velocity;
        private CustomVector3 _velocity;


        private CustomTransform(Transform transform)
        {               
            rotation = transform.rotation.eulerAngles;
            position = transform.position;
            _velocity = new CustomVector3(0.0f, 0.0f, 0.0f);
        }

        public void SetVelocity(Vector3 velocity)
        {
            _velocity = velocity;
        }
    }
}