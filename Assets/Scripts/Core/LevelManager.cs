using System.Collections.Generic;
using Asteroids.Abstraction;
using UnityEngine;

namespace Asteroids.Core
{
    public class LevelManager : ILevelManager
    {
        private ILevelModel _currentLevel;
        private readonly IDictionary<IModel<IModelInfo>, ILevelObjectView> _modelViews = new Dictionary<IModel<IModelInfo> , ILevelObjectView>();
        private readonly IDictionary<IModel<IModelInfo>, ILevelObjectView> _modelViewsTmp = new Dictionary<IModel<IModelInfo> , ILevelObjectView>();

        public void SetLevel(ILevelModel levelModel)
        {
            _currentLevel = levelModel;
        }

        public ILevelModel GetCurrentLevel() => _currentLevel;

        public T CreateObjectView<T>(IModel<IModelInfo> model, Vector3 position) where T : ILevelObjectView
        {
            var levelInfo = _currentLevel.GetInfo();
            
            GameObject go;
            
            if (_currentLevel.GameModel.CurViewMode == ViewMode.Poligone)
            {
                 go = Object.Instantiate(levelInfo.GetLevelObjectPrefab(model.GetInfo().ViewId3D), position,
                    Quaternion.identity);
            }
            else
            {
                 go = Object.Instantiate(levelInfo.GetLevelObjectPrefab(model.GetInfo().ViewId), position,
                    Quaternion.identity);
            }

            if (!go.TryGetComponent(out T result))
            {
                Debug.LogAssertion($"GameObjet {go.name} doesnt have {typeof(T)} component");
            }
            
            _modelViews.Add(model, result);
            
            return result;
        }

        public void ChangeAllView()
        {
            foreach (var modelView in _modelViews)
            {
                _modelViewsTmp.Add(modelView);
            }

            foreach (var modelView in _modelViewsTmp)
            {
                ChangeView<ILevelObjectView>(modelView.Key);
            }
        }
        public T ChangeView<T>(IModel<IModelInfo> model) where T : ILevelObjectView
        {
            
            var levelInfo = _currentLevel.GetInfo();
            var transform = model.GetTransform();
            
            DestroyView(model);
            GameObject go;
            
            if (_currentLevel.GameModel.CurViewMode == ViewMode.Poligone)
            {
                 go = Object.Instantiate(levelInfo.GetLevelObjectPrefab(model.GetInfo().ViewId3D), transform.position, 
                    Quaternion.Euler(transform.rotation));
                 go.GetComponent<Rigidbody>().velocity = transform.velocity;
                 
                 if (!go.TryGetComponent(out T result))
                 {
                     Debug.LogAssertion($"GameObjet {go.name} doesnt have {typeof(T)} component");
                 }
            
                 _modelViews.Add(model, result);
                 
                 return result;
            }
            
            else
            {
                 go = Object.Instantiate(levelInfo.GetLevelObjectPrefab(model.GetInfo().ViewId), transform.position , 
                    Quaternion.Euler(transform.rotation));
                 go.GetComponent<Rigidbody2D>().velocity = transform.velocity;
                 
                 if (!go.TryGetComponent(out T result))
                 {
                     Debug.LogAssertion($"GameObjet {go.name} doesnt have {typeof(T)} component");
                 }
            
                 _modelViews.Add(model, result);
                 
                 return result;
            }
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
                Object.Destroy(viewUnity.UnityTransform.gameObject);
            }
            
            _modelViews.Remove(model);
        }

        public void DestroyBehaviour(BaseBehavior behavior)
        {
            Object.Destroy(behavior);
        }
    }
}