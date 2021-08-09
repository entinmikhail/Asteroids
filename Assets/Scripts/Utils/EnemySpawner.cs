using System.Collections;
using System.Collections.Generic;
using Asteroids.Controller;

using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    private GameObject _asteroid;
    private IList<EnemyController> _controllers = new List<EnemyController>();
    
    private int _maxEnemyOnMap = 5;
    private int _curEnemyOnMap;

    private void Start()
    {
        _asteroid = Resources.Load<GameObject>("Asteroid");
        
        for (int i = 0; i < _maxEnemyOnMap; i++)
        {
            SpawnAsteroid();
            _curEnemyOnMap++;
        }
        
        for (int i = 0; i < _controllers.Count; i++)
        {
            _controllers[i].Init();
            _controllers[i].EnemyDestroyed += () => _curEnemyOnMap--;
        }
    }

    private void Update()
    {
        for (int i = 0; i < _controllers.Count; i++)
        {
            _controllers[i].SelfUpdate();
        }
        
        AddEnemy();
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
            _controllers.Add(enemyController);
        }
       
    }

    private IEnumerator SpawnAfterDelay()
    {
        yield return new WaitForSeconds(Random.Range(1.0f, 4.0f));
        SpawnAsteroid();
        
    }
}
