using System;
using Asteroids.Abstraction;
using Asteroids.ScriptableObjects;
using Asteroids.View;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Asteroids.Core.Teleporter
{
    public class AsteroidEnemy : IEnemy

    {
        private LevelObjectView _view;
        private EnemyInfo _enemyInfo;
        private float _maxSpeed;

        public AsteroidEnemy(LevelObjectView view, EnemyInfo enemyInfo)
        {
            _view = view;
            _enemyInfo = enemyInfo;
            _maxSpeed = enemyInfo.MovementSpeed;
        }

        public void DoSomeThingOnStart()
        {
            AddImpulse();
        }

        public void DoSomeThingOnUpdate()
        {
            /*hui*/
        }
        
        private void AddImpulse()
        {
            _view.Rigidbody2D.AddForce(new Vector2(Random.Range(-_maxSpeed, _maxSpeed),
                Random.Range(-_maxSpeed, _maxSpeed)), ForceMode2D.Impulse);
        }
    }
}