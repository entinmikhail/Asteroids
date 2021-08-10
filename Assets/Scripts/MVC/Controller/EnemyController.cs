using System;
using Asteroids.Abstraction;
using Asteroids.Core.Teleporter;
using Asteroids.Model;
using Asteroids.ScriptableObjects;
using Asteroids.View;
using UnityEngine;

namespace Asteroids.Controller
{
    public class EnemyController : MonoBehaviour

    {
        [SerializeField] private EnemyInfo _enemyInfo; 
        
        private HealthModel _healthModel;
        private LevelObjectView _enemyView;
        private Rigidbody2D _rigidbody;
        private IEnemy _enemy;

        public event Action<LevelObjectView> OnShellColision;
        public event Action<GameObject> EnemyDestroyed;
            
        public void Init()
        {
            _enemyView = gameObject.GetComponent<LevelObjectView>();

            _enemy = new AsteroidEnemy(_enemyView, _enemyInfo);
            _healthModel = new HealthModel(_enemyInfo);
            
            _enemy.DoSomeThingOnStart();
            _enemyView.OnGameObjectContact += OnCollision;
            _healthModel.Died += Dispose;
        }

        public void SelfUpdate()
        {
            /*_enemy.DoSomeThingOnUpdate();*/
        }

        private void OnCollision(GameObject obj)
        {
            if (obj.CompareTag("Shell"))
            {
                var shellView = obj.GetComponent<LevelObjectView>();
                var shellInfo = Resources.Load<ObjectsInfos>("ObjectsInfos").GetInfo(shellView.LevelObjectType); //
                OnShellColision?.Invoke(shellView);
                _healthModel.ChangeHealth(-shellInfo.DamageValue);
            }
        }

        private void Dispose()
        {
            EnemyDestroyed?.Invoke(gameObject);
            _enemyView.OnGameObjectContact -= OnCollision;
            _healthModel.Died -= Dispose;
        }
    }
}