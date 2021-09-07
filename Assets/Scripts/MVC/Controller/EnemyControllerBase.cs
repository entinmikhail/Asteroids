﻿using Asteroids.Abstraction;
using Asteroids.Model;
using UnityEngine;
using Utils;

namespace Asteroids.Controller
{
    public abstract class EnemyControllerBase : IEnemyController, IUpdatable 
    {
        public ILevelObjectView View { get; private set; }

        protected BaseEnemyBehavior _enemyBehaviour;

        protected readonly IEnemyInfo _enemyInfo;
        protected readonly ILevelManager _levelManager;

        protected IPlayerView _playerView;
        
        private IResourceModel _healthModel;
        private readonly IEnemy _enemy;
        
        private bool _inited;

        protected EnemyControllerBase(IEnemy enemy, ILevelManager levelManager)
        {
            _enemy = enemy;
            _enemyInfo = enemy.GetInfo();
            _levelManager = levelManager;
        }
        
        public void Start()
        {
            if (_inited) return;
            _inited = true;
            var position = GetStartPosition();
            
            View = _levelManager.GetObjectView<ILevelObjectView>(_enemyInfo.ViewId, position);
            _enemyBehaviour = _enemyInfo.EnemyBehavior;
            _healthModel = _enemy.GetResource(ProjConstants.HealthId);
            _playerView = _levelManager.GetPlayerView();
            
            _enemy.ChangeTransform(View.Transform);
            
            InitBehaviour();
            
            View.OnLevelObjectContact += OnCollision;
            _enemy.HealthEnded += OnEnemyDied;
        }

        protected abstract CustomVector3 GetStartPosition();

        protected abstract void InitBehaviour();
        
        public void Update(double deltaTime)
        {
            if(!_inited) return;
            
            _enemyBehaviour.OnUpdate(View, _playerView, _enemyInfo.MovementSpeed);
            _enemy.ChangeTransform(View.Transform);
        }
        
        private void OnCollision(ILevelObjectView selfObject, ILevelObjectView contactObject)
        {
            if (contactObject.Transform.gameObject.CompareTag("Shell")) // 
            {
                var shellInfo = _levelManager.GetCurrentLevel().GetInfo().GetWeaponInfo(contactObject.LevelObjectType);
                
                _healthModel.ChangeResource(-shellInfo.DamageValue);
            }
        }

        private void OnEnemyDied(IEnemy obj)
        {
            Dispose();
        }
        
        public void Dispose()
        {
            if (!_inited) return;
            _inited = false;
            
            View.OnLevelObjectContact -= OnCollision;
            _enemy.HealthEnded += OnEnemyDied;

            Object.Destroy(View.Transform.gameObject); // 
        }
    }
}