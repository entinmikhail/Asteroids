using System;
using Asteroids.Abstraction;
using Asteroids.ScriptableObjects;
using Asteroids.View;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Asteroids.Core.Teleporter
{
    public class AsteroidEnemy : IEnemy

    {
        private LevelObjectView _view;
        private EnemyInfo _enemyInfo;
        private GameObject _miniAsteroid;
        
        private float _maxSpeed;

        public AsteroidEnemy(LevelObjectView view, EnemyInfo enemyInfo)
        {
            _view = view;
            _enemyInfo = enemyInfo;
            _maxSpeed = enemyInfo.MovementSpeed;
            _miniAsteroid = Resources.Load<GameObject>("MiniAsteroid");
        }

        public void DoSomeThingOnStart()
        {
            AddImpulse();
        }

        public void DoSomeThingOnUpdate()
        {
            
        }

        public GameObject DoSomeThingOnDestroy(GameObject gameObject)
        {
            Debug.Log("asdasdas");
            return Object.Instantiate(_miniAsteroid, _view.Transform.forward, Quaternion.Euler(0, 90, 0));
        }
        
        private void AddImpulse()
        {
            _view.Rigidbody2D.AddForce(new Vector2(Random.Range(-_maxSpeed, _maxSpeed),
                Random.Range(-_maxSpeed, _maxSpeed)), ForceMode2D.Impulse);
        }
    }
}