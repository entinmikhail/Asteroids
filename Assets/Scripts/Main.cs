using Asteroids.View;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    [SerializeField] private PlayerView _playerView;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private GameObject _restartButton;
    [SerializeField] private GameObject _totalScore;
    
    private GameObject _playerGameObject;
    private PlayerController _playerController;
    
    private Vector3 _defoultPlayerPosition = new Vector3(0, 0);
    
    private void Awake()
    {
        CreatePlayer();
        _playerController.PlayerDead += OnPlayerDead;
        _playerController.Awake();
        _enemySpawner.SpawnerStart();

    }

    private void OnPlayerDead()
    {
        _playerGameObject.SetActive(false);
        
        UiSetActive(true);
        
        _playerController.PlayerDead -= OnPlayerDead;
  
    }

    private void Update()
    {
        _playerController?.Update();
        
        _enemySpawner.SpawnerUpdate();
    }

    public void Restart()
    {
        _enemySpawner.DestroyAllEnemies();
        _enemySpawner.SpawnerStart();
        UiSetActive(false);
        _playerGameObject.SetActive(true);
        _playerController.PlayerDead += OnPlayerDead;
        
        _playerController.OnEnable();
        _playerController._healthModel.SetHealth(1);
        _playerGameObject.transform.SetPositionAndRotation(_defoultPlayerPosition, new Quaternion());
    }

    private void UiSetActive(bool value)
    {
        _restartButton.SetActive(value); 
        _totalScore.SetActive(value);
    }

    private void CreatePlayer()
    {
        
        _playerGameObject = Instantiate(Resources.Load<GameObject>("Player"), _defoultPlayerPosition, new Quaternion());
        _playerController = new PlayerController(_playerGameObject.GetComponent<PlayerView>());
        
    }
}
