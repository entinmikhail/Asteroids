using System;
using Abstractions;
using Utils;

namespace Asteroids.Model
{
    public class TransformModel : ITransformModel

    {
        private CastomTransform _curTransform;
        private CastomTransform _prevTransform;
        
        public event Action<CastomTransform, CastomTransform> TransformChanged;

        public CastomTransform GetTransform() => _curTransform;


        public void ChangeTransform(CastomTransform newTransform)
        {
            _prevTransform = _curTransform;
            _curTransform = newTransform;

            TransformChanged?.Invoke(_prevTransform, _curTransform);
        }
    }
}
