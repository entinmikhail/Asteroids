using Asteroids.Abstraction;
using Asteroids.Core.Teleporter;
using Asteroids.ScriptableObjects;
using Asteroids.View;
using UnityEngine;

namespace Asteroids.Factories
{
    public static class EnemyFactory
    {
        public static IEnemy CreateAsteroidEnemy()
        {
            var asteroid = Resources.Load<GameObject>("Asteroid");
            
            return new AsteroidEnemyController(asteroid.GetComponent<LevelObjectView>(),
                Resources.Load<EnemyInfo>("AsteroidEnemyInfo"));
        }

        /*public static IEnemy CreateUFOEnemy()
        {
            
        }*/
    }
}