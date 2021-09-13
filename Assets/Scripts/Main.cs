using Asteroids.Abstraction;
using Asteroids.Controller;
using Asteroids.Core;
using Asteroids.Model;
using Asteroids.ScriptableObjects;
using UnityEngine;
using Zenject;

public class Main : MonoBehaviour
{
    [SerializeField] private LevelInfo _levelInfo;
    
    [Inject] private GameModel _gameModel;
    [Inject] private PointModel _pointModel;

    private GameObject _playerGameObject;
    private PlayerController _playerController;
    private InputHandler _inputHandler;
    private GameObject[] _bulletsList;
    
    private ILevelManager _levelManger;
    private LevelController _levelController;
    private ILevelModel _levelModel;
    private IPlayer _player;

    public void Restart()
    {
        _pointModel.ResetValue();
        
        _playerController.Dispose();
        _playerController.Start();
        
        _levelController.Dispose();
        _levelController.Start();
        
        _gameModel.RestartGame();
    }

    private void Awake()
    {
        ModelFactory.RegisterEnemies();
        ControllerFactory.RegisterControllers();
        ShellControllerFactory.RegisterControllers();
        ShellModelFactory.RegisterEnemies();
        
        _inputHandler = new InputHandler();
        _inputHandler.Awake();
        _player = new Player(_levelInfo.GetPlayerInfo());

        _levelModel = new LevelModel(_levelInfo, _player);
        _levelManger = new LevelManager();
        _levelManger.SetLevel(_levelModel);
        
        _levelController = new LevelController(_pointModel, _levelManger);
        _playerController = new PlayerController(_levelModel.CurrentPlayer, _inputHandler, _levelManger);
        
        _playerController.Start();
        _levelController.Start();
        
        _player.HealthEnded += OnPlayerDead;
    }

    private void OnPlayerDead(IModel<IPlayerInfo> player)
    { 
        _gameModel.EndGame();
    }

    private void Update()
    {
        _playerController?.Update(Time.deltaTime);
        
        _levelController?.Update(Time.deltaTime);
        
        _inputHandler?.Update(Time.deltaTime);
    }
}
