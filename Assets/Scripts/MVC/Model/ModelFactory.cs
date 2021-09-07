using System;
using System.Collections.Generic;
using Asteroids.Abstraction;
using Utils;

namespace Asteroids.Model
{
    public static class ModelFactory
    {
        private static readonly IDictionary<string, Func<object[], IEnemy>> _enemyItems = new Dictionary<string, Func<object[], IEnemy>>();
        public static void RegisterEnemies()
        {
            _enemyItems.Add("asteroid", (objects) => new Asteroid((IEnemyInfo)objects[0]));
            _enemyItems.Add("mini_asteroid", (objects) => new MiniAsteroid((IEnemyInfo)objects[0], (CustomVector3)objects[1]));
            _enemyItems.Add("ufo", (objects) => new UFO((IEnemyInfo)objects[0]));
        }
        
        public static T Build<T>(string id, params object[] buildParams) where T : IEnemy
        {
            return (T) _enemyItems[id].Invoke(buildParams);
        }
    }
}