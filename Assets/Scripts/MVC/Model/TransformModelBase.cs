using System;
using Abstractions;
using Utils;

namespace Asteroids.Model
{
    public abstract class TransformModelBase : ITransformModel

    {
        private CustomTransform _curTransform;
        private CustomTransform _prevTransform;
        
        public event Action<CustomTransform, CustomTransform> TransformChanged;

        public CustomTransform GetTransform() => _curTransform;


        public void ChangeTransform(CustomTransform newTransform)
        {
            _prevTransform = _curTransform;
            _curTransform = newTransform;

            TransformChanged?.Invoke(_prevTransform, _curTransform);
        }
    }
}
