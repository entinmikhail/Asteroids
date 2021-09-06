using System;
using Utils;

namespace Abstractions
{
    public interface ITransformModel
    {
        public event Action<CastomTransform, CastomTransform> TransformChanged;
        
        public CastomTransform GetTransform();
        
        public void ChangeTransform(CastomTransform newTransform);
    }
}