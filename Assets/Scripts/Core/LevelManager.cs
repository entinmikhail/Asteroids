using System;
using System.Collections.Generic;
using System.Linq;
using Asteroids.Abstraction;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Asteroids.Core
{
    public class LevelManager : ILevelManager
    {
        private ILevelModel _currentLevel;
        
        private readonly IDictionary<IModel<IModelInfo>, ILevelObjectView> _modelViews = new Dictionary<IModel<IModelInfo> , ILevelObjectView>();
        private IDictionary<IModel<IModelInfo>, ILevelObjectView> _modelViewsTmp = new Dictionary<IModel<IModelInfo> , ILevelObjectView>();
        private Dictionary<IModel<IModelInfo>, BaseBehavior> _behaviors = new Dictionary<IModel<IModelInfo>, BaseBehavior>();
        
        public event Action<IModel<IModelInfo>> ViewChanged;
        
        public ILevelModel GetCurrentLevel() => _currentLevel;
        
        public void SetLevel(ILevelModel levelModel)
        {
            _currentLevel = levelModel;
        }

        public T CreateObjectView<T>(IModel<IModelInfo> model) where T : ILevelObjectView
        {
            GameObject go;

            var levelInfo = _currentLevel.GetInfo();
            
            Vector3 position = _behaviors[model].GetStartPosition(this, model);

            if (_currentLevel.GameModel.CurViewMode == ViewMode.Poligone)
            {
                 go = Object.Instantiate(levelInfo.GetLevelObjectPrefab(model.GetInfo().ViewId3D),
                     position, Quaternion.identity);
            }
            else
            {
                 go = Object.Instantiate(levelInfo.GetLevelObjectPrefab(model.GetInfo().ViewId), 
                     position, Quaternion.identity);
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
                if(modelView.Key is IPlayer) continue;
                _modelViewsTmp.Add(modelView);
            }

            foreach (var modelView in _modelViewsTmp)
            {
                if(modelView.Key is IPlayer) continue;
                ChangeView<ILevelObjectView>(modelView.Key);
            }

            _modelViewsTmp = new Dictionary<IModel<IModelInfo> , ILevelObjectView>();
        }
        
        public T ChangeView<T>(IModel<IModelInfo> model) where T : ILevelObjectView
        {
            var levelInfo = _currentLevel.GetInfo();
            var transform = model.GetTransform();
            
            DestroyView(model);
            GameObject go;
            T result;
            if (_currentLevel.GameModel.CurViewMode == ViewMode.Poligone)
            {
                 go = Object.Instantiate(levelInfo.GetLevelObjectPrefab(model.GetInfo().ViewId3D), transform.position, 
                    Quaternion.Euler(transform.rotation));
                 if(go.TryGetComponent<Rigidbody>(out var rigidbody))
                 {
                     rigidbody.velocity = transform.velocity;
                 }
                 
                 if (!go.TryGetComponent(out result))
                 {
                     Debug.LogAssertion($"GameObjet {go.name} doesnt have {typeof(T)} component");
                 }
            
                 _modelViews.Add(model, result);
            }
            else
            {
                 go = Object.Instantiate(levelInfo.GetLevelObjectPrefab(model.GetInfo().ViewId), transform.position , 
                    Quaternion.Euler(transform.rotation));
                 go.GetComponent<Rigidbody2D>().velocity = transform.velocity;
                 
                 if (!go.TryGetComponent(out result))
                 {
                     Debug.LogAssertion($"GameObjet {go.name} doesnt have {typeof(T)} component");
                 }
                 _modelViews.Add(model, result);
            }

            ViewChanged?.Invoke(model);
            
            return result;
        }

        public TView GetOrCreateView<TView>(IModel<IModelInfo> model) where TView : ILevelObjectView
        {
            if (!_modelViews.TryGetValue(model, out var view))
            {
                Debug.LogAssertion($"Model {model.GetInfo().ViewId} doesnt have view");
                return CreateObjectView<TView>(model);
            }

            if (view is TView tView) return tView;
            
            _modelViews.Remove(model);
                
            return CreateObjectView<TView>(model);
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

        public BaseBehavior CreateBehavior(ViewMode viewMode, IModel<IModelInfo> model)
        {
            var beh = Object.Instantiate(model.GetInfo().GetBehavior(viewMode));
            _behaviors.Add(model, beh);
            
            return beh;
        }
        
        public void DestroyBehaviour(BaseBehavior behavior)
        {
            _behaviors.Remove(_behaviors.FirstOrDefault(x => x.Value == behavior).Key);
            Object.Destroy(behavior);
        }
    }
}