using System;
using System.Collections;
using System.Collections.Generic;
using Asteroids.Controller;
using Asteroids.Model;
using Asteroids.ScriptableObjects;
using Asteroids.View;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [Inject] private PointModel _pointModel;
    
    private GameObject _asteroid;
    private GameObject _miniAsteroid;
    private IList<EnemyController> _controllers = new List<EnemyController>();
    private IList<GameObject> _enemies = new List<GameObject>();
   
    
    private int _maxEnemyOnMap = 5;
    private int _maxAsteroidsOnMap;
    private int _curEnemyOnMap;
    
    private int _countOfMiniAsteroids = 4;
    
    public Action<float> EnemyDeaded;
    
    public void SpawnerStart()
    {

        EnemyDeaded += _pointModel.ChangeResource;

        _asteroid = Resources.Load<GameObject>("Asteroid");
        _miniAsteroid = Resources.Load<GameObject>("MiniAsteroid");

        for (int i = 0; i < _maxEnemyOnMap; i++)
        {
            SpawnEnemy(new Vector3(Random.Range(-9.0f, 9.0f), Random.Range(-5.0f, 5.0f), 0), _asteroid, new Quaternion());
        }
    }

    public void SpawnerUpdate()
    {
        for (int i = 0; i < _controllers.Count; i++)
        {
            _controllers[i].SelfUpdate();
        }
        
        AddEnemy();
    }

    private void SpawnerDetach()
    {
        EnemyDeaded -= _pointModel.ChangeResource;   
    }
    
    private void AddEnemy()
    {
        if (_curEnemyOnMap < _maxEnemyOnMap)
        {
            SpawnEnemy(new Vector3(Random.Range(-9.0f, 9.0f), Random.Range(-5.0f, 5.0f), 0), _asteroid, new Quaternion());
        }
    }
    
    private void SpawnEnemy(Vector3 spawnPosition, GameObject enemy, Quaternion spawnDerection)
    {
        _curEnemyOnMap++;
        
        var go = Instantiate(enemy, spawnPosition, spawnDerection);
        
        if (go.TryGetComponent<EnemyController>(out var enemyController))
        {
            _enemies.Add(go);
            _controllers.Add(enemyController);
            
            enemyController.Init();
            enemyController.EnemyDestroyed += DestroyEnemy;
        }
    }

    private void DestroyEnemy(GameObject enemy, LevelObjectView lastCollision)
    {
        var levelObject = enemy.GetComponent<LevelObjectView>();
        var enemyController = enemy.GetComponent<EnemyController>();
        
        if (lastCollision != null && lastCollision.gameObject.CompareTag("Shell"))
        {
            if (levelObject.LevelObjectType == LevelObjectType.Asteroid)
            {
                var localPosition = enemy.transform.localPosition;
                
                for (int i = 0; i < _countOfMiniAsteroids; i++)
                {
                    var y = 360 / _countOfMiniAsteroids * (i + 1);
                    
                    SpawnEnemy(localPosition, _miniAsteroid, Quaternion.Euler(0, 0,0));
                }
            } 
        }
        
        _curEnemyOnMap--;

        _enemies?.Remove(enemy);
        _controllers?.Remove(enemyController);
        
        enemyController.EnemyDestroyed -= DestroyEnemy;
        
        EnemyDeaded?.Invoke(10.0f); // поинты
        
        Destroy(enemy);
    }

    public void DestroyAllEnemies()
    {
        for (var i = _enemies.Count - 1; i > -1; i--)
        {
            DestroyEnemy(_enemies[i], null);
            EnemyDeaded?.Invoke(-10.0f);
        }
    }
}
