using System;
using Asteroids.Abstraction;
using Asteroids.Core.Teleporter;
using Asteroids.Model;
using Asteroids.ScriptableObjects;
using Asteroids.View;
using UnityEngine;
using Zenject;

namespace Asteroids.Controller
{
    public class EnemyController : MonoBehaviour

    {
        [SerializeField] private EnemyInfo _enemyInfo;
        [Inject] private PlayerView _playerView;
        
        private ResourceModel _healthModel;
        private LevelObjectView _enemyView;
        private Rigidbody2D _rigidbody;
        private BaseEnemyMoveBehavior _enemyBehevior;
        private LevelObjectView _lastCollision;

        public event Action<LevelObjectView> OnShellColision;
        public event Action<GameObject, LevelObjectView> EnemyDestroyed;
            
        public void Init()
        {
            _enemyView = gameObject.GetComponent<LevelObjectView>();

            _enemyBehevior = _enemyInfo.EnemyMoveBehavior;
            
            _healthModel = new ResourceModel(_enemyInfo.Health, _enemyInfo.MaxHealth);
            
            _enemyBehevior.Init(_enemyView, _playerView, _enemyInfo.MovementSpeed);
            
            _enemyView.OnGameObjectContact += OnCollision;
            _healthModel.ResourceEnded += Dispose;
        }

        public void SelfUpdate()
        {
            _enemyBehevior.OnUpdate(_enemyView, _playerView, _enemyInfo.MovementSpeed);
        }

        private void OnCollision(GameObject obj)
        {
            if (obj.CompareTag("Shell"))
            {
                var shellView = obj.GetComponent<LevelObjectView>();
                var shellInfo = Resources.Load<ObjectsInfos>("ObjectsInfos").GetInfo(shellView.LevelObjectType); //
                
                _lastCollision = shellView;
                _healthModel.ChangeResource(-shellInfo.DamageValue);
                
                OnShellColision?.Invoke(shellView);
            }
        }

        private void Dispose()
        {
            EnemyDestroyed?.Invoke(gameObject, _lastCollision);
            
            _enemyView.OnGameObjectContact -= OnCollision;
            _healthModel.ResourceEnded -= Dispose;
        }
    }
}