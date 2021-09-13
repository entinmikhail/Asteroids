using System.Collections.Generic;
using Asteroids.Abstraction;
using UnityEngine;

namespace Asteroids.Core
{
    public class LevelManager : ILevelManager
    {
        private ILevelModel _currentLevel;
        private readonly IDictionary<IModel<IModelInfo>, ILevelObjectView> _modelViews = new Dictionary<IModel<IModelInfo> , ILevelObjectView>();
        
        public void SetLevel(ILevelModel levelModel)
        {
            _currentLevel = levelModel;
        }

        public ILevelModel GetCurrentLevel() => _currentLevel;

        public T CreateObjectView<T>(IModel<IModelInfo> model, Vector3 position) where T : ILevelObjectView
        {
            var levelInfo = _currentLevel.GetInfo();

            var go = Object.Instantiate(levelInfo.GetLevelObjectPrefab(model.GetInfo().ViewId), position, Quaternion.identity);
            if (!go.TryGetComponent(out T result))
            {
                Debug.LogAssertion($"GameObjet {go.name} doesnt have {typeof(T)} component");
            }
            
            _modelViews.Add(model, result);
            
            return result;
        }

        public TView GetOrCreateView<TView>(IModel<IModelInfo> model) where TView : ILevelObjectView
        {
            if (!_modelViews.TryGetValue(model, out var view))
            {
                Debug.LogAssertion($"Model {model.GetInfo().ViewId} doesnt have view");
                return CreateObjectView<TView>(model, Vector3.zero); // todo remove position declaration
            }

            if (view is TView tView) return tView;
     
            _modelViews.Remove(model);
                
            return CreateObjectView<TView>(model, Vector3.zero);
        }


        public void DestroyView(IModel<IModelInfo> model)
        {
            if (!_modelViews.TryGetValue(model, out var view))
            {
                Debug.LogAssertion($"Model {model.GetInfo().ViewId} doesnt have view");
                return;
            }

            if (view is ILevelObjectViewUnity viewUnity)
            {
                Object.Destroy(viewUnity.UnityTransfom.gameObject);
            }
            
            _modelViews.Remove(model);
        }

        public void DestroyBehaviour(BaseBehavior behavior)
        {
            Object.Destroy(behavior);
        }
    }
}