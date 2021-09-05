using System;

namespace Asteroids.Abstraction
{
    public interface IPointModel
    {
        public event Action ResourceEnded;

        void SetResourceValue(float resourceValue);
        
        float GetCurrentResourceValue();
        
        void ChangeResource(float changeValue);
        void ProceedEnemyDied(IEnemy enemy);
    }
}