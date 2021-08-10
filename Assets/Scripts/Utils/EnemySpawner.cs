using System;
using System.Collections;
using System.Collections.Generic;
using Asteroids.Controller;
using Asteroids.Model;
using Asteroids.ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    private GameObject _asteroid;
    private IList<EnemyController> _controllers = new List<EnemyController>();
    
    private HealthModel _pointModel; //)))))))))))))))))))))))))))))))))))))))))))))))))))))))))))
    
    private int _maxEnemyOnMap = 5;
    private int _curEnemyOnMap;

    [SerializeField] private Text _scoreCounter;
    
    public Action<float> EnemyIsDeaded;

    public Action<float, float> asd; //
    
    private void Start()
    {
        _pointModel = new HealthModel(Resources.Load<ShipInfo>("ShipInfo"));
        
        EnemyIsDeaded += _pointModel.ChangeHealth;
        
        _pointModel.HealthIsChanged += ChangePoints; //
        
        _asteroid = Resources.Load<GameObject>("Asteroid");

        for (int i = 0; i < _maxEnemyOnMap; i++)
        {
            SpawnAsteroid();
            _curEnemyOnMap++;
        }
    }

    private Action<float, float> ChangePoints(float curvalue, float prevvalue) //
    { ;
        _scoreCounter.text = $"Score: {curvalue}"; 
        
        return asd;
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
            enemyController.Init();
            enemyController.EnemyDestroyed += DestroyEnemy;
        }
       
    }

    private IEnumerator SpawnAfterDelay()
    {
        yield return new WaitForSeconds(Random.Range(1.0f, 4.0f));
        SpawnAsteroid();
    }

    private void DestroyEnemy(GameObject enemyGO)
    {
        _controllers?.Remove(enemyGO.GetComponent<EnemyController>());
        
        EnemyIsDeaded?.Invoke(10.0f); //
        
        Destroy(enemyGO);
        
        _curEnemyOnMap--;
    }
}
