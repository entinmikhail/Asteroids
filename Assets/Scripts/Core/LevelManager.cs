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

        public T CreateObjectView<T>(string id, IModel<IModelInfo> model, Vector3 position) where T : ILevelObjectView
        {
            var levelInfo = _currentLevel.GetInfo();

            var go = Object.Instantiate(levelInfo.GetLevelObjectPrefab(id), position, Quaternion.identity);
            if (!go.TryGetComponent(out T result))
            {
                Debug.LogAssertion($"GameObjet {go.name} doesnt have {typeof(T)} component");
            }
            
            _modelViews.Add(model, result);
            
            return result;
        }
        
        public TView GetView<TView>(IModel<IModelInfo> model) where  TView : ILevelObjectView => (TView) _modelViews[model];

        
        public void DestroyView(IModel<IModelInfo> model, ILevelObjectView view)
        {
            _modelViews.Remove(model);
            
            Object.Destroy(view.Transform.gameObject);
        }
    }
}