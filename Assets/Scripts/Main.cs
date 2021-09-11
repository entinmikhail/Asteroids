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
    [SerializeField] private PlayerInfo _playerInfo;
    
    [Inject] private HealthModel _healthModel;
    [Inject] private GameModel _gameModel;
    [Inject] private PointModel _pointModel;

    private GameObject _playerGameObject;
    private PlayerController _playerController;
    private InputHandler _inputHandler;
    private GameObject[] _bulletsList;
    
    private readonly Vector3 _defaultPlayerPosition = new Vector3(0, 0);
    private readonly Quaternion _defaultRotation = new Quaternion();
    
    private ILevelManager _levelManger;
    private LevelController _levelController;
    private ILevelModel _levelModel;

    public void Restart()
    {
        _gameModel.RestartGame();
        
        _pointModel.ResetValue();
        
        _levelController.Dispose();
        _levelController.Start();
        
        
        _playerGameObject.SetActive(true);

        _playerGameObject.transform.SetPositionAndRotation(_defaultPlayerPosition, _defaultRotation);

        _playerController.Dispose();
        _playerController.Start();
    }

    private void Awake()
    {
        ModelFactory.RegisterEnemies();
        ControllerFactory.RegisterControllers();
        ShellControllerFactory.RegisterControllers();
        ShellModelFactory.RegisterEnemies();
        
        _inputHandler = new InputHandler();
        _inputHandler.Awake();

        
        _playerGameObject = Instantiate(Resources.Load<GameObject>("Player"), _defaultPlayerPosition, _defaultRotation);
        _levelModel = new LevelModel(_levelInfo);
        _levelManger = new LevelManager(_playerGameObject.GetComponent<PlayerView>());
        _levelManger.SetLevel(_levelModel);
        
        _levelController = new LevelController(_pointModel, _levelManger);
        _playerController = new PlayerController(_playerGameObject.GetComponent<PlayerView>(), _healthModel, _gameModel, _playerInfo, _inputHandler, _levelManger);

        CreatePlayer();
        _playerController.Start();
        _levelController.Start();
        _playerController.PlayerDead += OnPlayerDead;
        
    }
    
    private void Update()
    {

      
        
        
        _playerController?.Update(Time.deltaTime);
        
        _levelController?.Update(Time.deltaTime);
        
        _inputHandler?.Update(Time.deltaTime);
    }

    private void OnPlayerDead()
    {
        _playerGameObject.SetActive(false);
    }

    private void CreatePlayer()
    {
        
    }
}
