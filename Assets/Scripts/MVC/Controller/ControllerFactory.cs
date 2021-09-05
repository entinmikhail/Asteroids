using System;
using System.Collections.Generic;
using Asteroids.Abstraction;

namespace Asteroids.Controller
{
    public static class ControllerFactory
    {
        private static readonly IDictionary<string, Func<object[], IEnemyController>> _controllersItems = new Dictionary<string, Func<object[], IEnemyController>>();

        public static void RegisterControllers()
        {
            _controllersItems.Add("asteroid", objects => new EnemyController((IEnemy)objects[0], (ILevelManager)objects[1]));
            _controllersItems.Add("mini_asteroid", objects => new MiniAsteroidController((IEnemy)objects[0], (ILevelManager)objects[1]));
            _controllersItems.Add("ufo", objects => new EnemyController((IEnemy)objects[0], (ILevelManager)objects[1]));
        }
        
        public static T Build<T>(string id, params object[] buildParams) where T : IEnemyController
        {
            return (T) _controllersItems[id].Invoke(buildParams);
        }
    }
}