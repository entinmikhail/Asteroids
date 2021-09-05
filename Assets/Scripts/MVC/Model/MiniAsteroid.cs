using Asteroids.Abstraction;
using UnityEngine;

namespace Asteroids.Model
{
    public class MiniAsteroid : EnemyBase
    {
        public Vector3 InitialPosition { get; private set; }
        public MiniAsteroid(IEnemyInfo enemyInfo, Vector3 initialPosition) : base(enemyInfo)
        {
            InitialPosition = initialPosition;
        }
    }
}