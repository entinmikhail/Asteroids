using Asteroids.Model;
using Asteroids.View;
using UnityEngine;
using Zenject;

public class Main : MonoBehaviour
{
    [SerializeField] private EnemySpawner _enemySpawner;

    [Inject] private HealthModel _healthModel;
    [Inject] private GameModel _gameModel;
    [Inject] private PointModel _pointModel;
    
    private GameObject _playerGameObject;
    private PlayerController _playerController;

    private Vector3 _defoultPlayerPosition = new Vector3(0, 0);
    private Quaternion _defoultRotation = new Quaternion();

    public void Restart()
    {
        _pointModel.ResetValue();
        _enemySpawner.DestroyAllEnemies();
        _enemySpawner.EnemyDeaded -= _pointModel.ChangeResource; 
        
        _enemySpawner.SpawnerStart();

        _playerGameObject.SetActive(true);

        _playerController.OnEnable();
        _healthModel.SetResourceValue(1);
        
        _playerGameObject.transform.SetPositionAndRotation(_defoultPlayerPosition, _defoultRotation);
        
        _gameModel.RestartGame();
    }

    private void Awake()
    {
        CreatePlayer();
        
        _playerController.Awake();
        _enemySpawner.SpawnerStart();
        
        _playerController.PlayerDead += OnPlayerDead;
    }



    private void Update()
    {
        
        
        _playerController?.Update();
        
        _enemySpawner.SpawnerUpdate();
    }

    private void OnPlayerDead()
    {
        _playerGameObject.SetActive(false);
    }

    private void CreatePlayer()
    {
        _playerGameObject = Instantiate(Resources.Load<GameObject>("Player"), _defoultPlayerPosition, _defoultRotation);
        _playerController = new PlayerController(_playerGameObject.GetComponent<PlayerView>(), _healthModel);
    }
}
