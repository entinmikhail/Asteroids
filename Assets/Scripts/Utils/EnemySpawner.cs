using System;
using System.Collections;
using System.Collections.Generic;
using Asteroids.Controller;
using Asteroids.Model;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [Inject] private PointModel _pointModel;
    
    private GameObject _asteroid;
    private IList<EnemyController> _controllers = new List<EnemyController>();
    private IList<GameObject> _enemies = new List<GameObject>();
   
    
    private int _maxEnemyOnMap = 5;
    private int _curEnemyOnMap;
    
    public Action<float> EnemyDeaded;
    
    public void SpawnerStart()
    {

        EnemyDeaded += _pointModel.ChangeResource;

        _asteroid = Resources.Load<GameObject>("Asteroid");

        for (int i = 0; i < _maxEnemyOnMap; i++)
        {
            SpawnAsteroid();
            _curEnemyOnMap++;
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
            _curEnemyOnMap++;
            StartCoroutine(SpawnAfterDelay());
        }
    }
    
    private void SpawnAsteroid()
    {
        var position = new Vector3(Random.Range(-9.0f, 9.0f), Random.Range(-5.0f, 5.0f), 0);
         
        var go = Instantiate(_asteroid, position, new Quaternion());
        
        if (go.TryGetComponent<EnemyController>(out var enemyController))
        {
            _enemies.Add(go);
            _controllers.Add(enemyController);
            
            enemyController.Init();
            enemyController.EnemyDestroyed += DestroyEnemy;
        }
       
    }

    private IEnumerator SpawnAfterDelay()
    {
        yield return new WaitForSeconds(Random.Range(1.0f, 4.0f));
        SpawnAsteroid();
    }

    private void DestroyEnemy(GameObject enemy)
    {
        var enemyController = enemy.GetComponent<EnemyController>();
        
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
            DestroyEnemy(_enemies[i]);
            EnemyDeaded?.Invoke(-10.0f);
        }
    }
}
