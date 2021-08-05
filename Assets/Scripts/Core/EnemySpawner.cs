using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    private GameObject _asteroid;
    
    private int _maxEnemyOnMap = 5;
    private int _curEnemyOnMap;

    private void Start()
    {
        _asteroid = Resources.Load<GameObject>("Asteroid");
        
        for (int i = 0; i < _maxEnemyOnMap; i++)
        {
            SpawnEnemy();
            _curEnemyOnMap++;
        }
    }

    private void Update()
    {
        AddEnemy();
    }

    private void AddEnemy()
    {
        if (_curEnemyOnMap < _maxEnemyOnMap)
        {
            StartCoroutine(Wait());
            SpawnEnemy();
            _curEnemyOnMap++;
        }
    }
    
    private void SpawnEnemy()
    {
        var position = new Vector3(Random.Range(-9.0f, 9.0f), Random.Range(-5.0f, 5.0f), 0);
            
        Instantiate(_asteroid, position, new Quaternion());
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(Random.Range(1.0f, 4.0f));
    }
}
