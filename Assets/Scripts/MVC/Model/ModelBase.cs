using System;
using Asteroids.Abstraction;
using UnityEngine;

namespace Asteroids.Model
{
    public abstract class ModelBase<TInfo> : TransformModelBase, IModel<TInfo> where TInfo : IModelInfo
    {
        protected readonly TInfo _info;
        private readonly IResourceModel _healthModel;

        public abstract TInfo GetInfo();
        
        public event Action<IModel<TInfo>> HealthEnded;

        protected ModelBase(TInfo info)
        {
            _info = info;
            _healthModel = new ResourceModel(_info.Health, _info.MaxHealth);

            _healthModel.ResourceEnded += OnHeathEnded;
        }

        private void OnHeathEnded()
        {
            HealthEnded?.Invoke(this);
        }

        public IResourceModel GetResource(int id)
        {
            return id == ProjConstants.HealthId ? _healthModel : null;
        }
    }
}