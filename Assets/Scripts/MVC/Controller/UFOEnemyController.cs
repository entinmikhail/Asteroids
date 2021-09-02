using Asteroids.Abstraction;
using Asteroids.ScriptableObjects;
using Asteroids.View;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace Asteroids.Controller
{
    public class UFOEnemyController : IEnemy

    {
        private LevelObjectView _view;
        private PlayerView _playerView;
        private EnemyInfo _enemyInfo;
        
        private float _speed;

        public UFOEnemyController(LevelObjectView view, PlayerView playerView, EnemyInfo enemyInfo)
        {
            _view = view;
            _playerView = playerView;
            _enemyInfo = enemyInfo;
            _speed = _enemyInfo.MovementSpeed;
        }

        public void DoSomeThingOnStart()
        {
        }

        public void DoSomeThingOnUpdate()
        {
            ChaseCharacter();
        }

        private void ChaseCharacter()
        {
            _view.Transform.position = Vector2.MoveTowards(_view.Transform.position,
                _playerView.Transform.position, _speed * Time.deltaTime);
        } 
    }


}