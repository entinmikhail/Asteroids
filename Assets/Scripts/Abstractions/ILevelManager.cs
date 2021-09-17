using System;
using UnityEngine;

namespace Asteroids.Abstraction
{
    public interface ILevelManager
    {
        event Action<IModel<IModelInfo>> ViewChanged;
        ILevelModel GetCurrentLevel();
        T CreateObjectView<T>(IModel<IModelInfo> model)  where T : ILevelObjectView;
        void SetLevel(ILevelModel levelModel);
        TView GetOrCreateView<TView>(IModel<IModelInfo> model) where TView : ILevelObjectView;
        T ChangeView<T>(IModel<IModelInfo> model) where T : ILevelObjectView;
        void DestroyView(IModel<IModelInfo> model);
        void DestroyBehaviour(BaseBehavior behavior);
        BaseBehavior CreateBehavior(ViewMode viewMode, IModel<IModelInfo> model);
        void ChangeAllView();
    }
}