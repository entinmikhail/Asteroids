using Asteroids.Abstraction;
using Asteroids.Controller;
using Asteroids.Core;
using Asteroids.Model;
using Asteroids.ScriptableObjects;
using Asteroids.View;
using UnityEngine;
using Zenject;

public class Main : MonoBehaviour
{
    [SerializeField] private LevelInfo _levelInfo;
        
    [Inject] private HealthModel _healthModel;
    [Inject] private GameModel _gameModel;
    [Inject] private PointModel _pointModel;

    private GameObject _playerGameObject;
    private PlayerController _playerController;

    private GameObject[] _bulletsList;
    
    private readonly Vector3 _defaultPlayerPosition = new Vector3(0, 0);
    private readonly Quaternion _defaultRotation = new Quaternion();
    
    private ILevelManager _levelManger;
    private LevelController _levelController;
    private ILevelModel _levelModel;

    public void Restart()
    {
        _pointModel.ResetValue();
        
        _levelController.Dispose();
        _levelController.Start();
        
        _playerGameObject.SetActive(true);

        _playerController.OnEnable();
        _healthModel.SetResourceValue(1);
        
        _playerGameObject.transform.SetPositionAndRotation(_defaultPlayerPosition, _defaultRotation);
        
        _gameModel.RestartGame();
    }

    private void Awake()
    {
        ModelFactory.RegisterEnemies();
        ControllerFactory.RegisterControllers();
        
        CreatePlayer();
        _levelModel = new LevelModel(_levelInfo);
        _levelManger = new LevelManager(_playerGameObject.GetComponent<PlayerView>());
        _levelManger.SetLevel(_levelModel);
        
        _levelController = new LevelController(_pointModel, _levelManger);
        
        _playerController.Awake();
        _levelController.Start();
        
        _playerController.PlayerDead += OnPlayerDead;
    }
    
    private void Update()
    {
        _playerController?.Update();
        
        _levelController.Update(Time.deltaTime);
    }

    private void OnPlayerDead()
    {
        _playerGameObject.SetActive(false);
    }

    private void CreatePlayer()
    {
        _playerGameObject = Instantiate(Resources.Load<GameObject>("Player"), _defaultPlayerPosition, _defaultRotation);
        _playerController = new PlayerController(_playerGameObject.GetComponent<PlayerView>(), _healthModel, _gameModel);
    }
}
