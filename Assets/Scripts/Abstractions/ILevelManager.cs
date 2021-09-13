using UnityEngine;

namespace Asteroids.Abstraction
{
    public interface ILevelManager
    {
        ILevelModel GetCurrentLevel();
        T CreateObjectView<T>(IModel<IModelInfo> model, Vector3 position)  where T : ILevelObjectView;
        void SetLevel(ILevelModel levelModel);
        TView GetOrCreateView<TView>(IModel<IModelInfo> model) where TView : ILevelObjectView;
        void DestroyView(IModel<IModelInfo> model);
        void DestroyBehaviour(BaseBehavior behavior);
    }
}