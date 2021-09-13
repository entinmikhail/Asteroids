using UnityEngine;

namespace Asteroids.Abstraction
{
    public interface ILevelManager
    {
        ILevelModel GetCurrentLevel();
        T CreateObjectView<T>(string id, IModel<IModelInfo> model, Vector3 position)  where T : ILevelObjectView;
        void SetLevel(ILevelModel levelModel);
        TView GetView<TView>(IModel<IModelInfo> model) where TView : ILevelObjectView;
        void DestroyView(IModel<IModelInfo> model, ILevelObjectView view);
    }
}