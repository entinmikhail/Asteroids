using System;
using Utils;

namespace Abstractions
{
    public interface ITransformModel
    {
        public event Action<CustomTransform, CustomTransform> TransformChanged;
        public CustomTransform GetTransform();
        public void SetTransform(CustomTransform newTransform);
    }
}