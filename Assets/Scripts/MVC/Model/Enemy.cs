using System;
using Asteroids.Abstraction;

namespace Asteroids.Model
{
    public abstract class EnemyBase: IEnemy
    {
        private readonly IEnemyInfo _enemyInfo;
        private readonly IResourceModel _healthModel;
        
        private float _maxSpeed;
        
        public event Action<IEnemy> HealthEnded;

        protected EnemyBase(IEnemyInfo enemyInfo)
        {
            _enemyInfo = enemyInfo;
            _healthModel = new ResourceModel(_enemyInfo.Health, _enemyInfo.MaxHealth);
            _healthModel.ResourceEnded += OnHeathEnded;
        }

        private void OnHeathEnded()
        {
            HealthEnded?.Invoke(this);
        }
        
        public IEnemyInfo GetInfo() => _enemyInfo;

        public IResourceModel GetResource(int id)
        {
            return id == ProjConstants.HealthId ? _healthModel : null;
        }
    }
}