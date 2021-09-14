using Asteroids.Abstraction;
using Asteroids.Controller;
using Asteroids.Core;
using Asteroids.Model;
using Asteroids.ScriptableObjects;
using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField] private LevelInfo _levelInfo;
    [SerializeField] private UIController _uiController;
    
    private IGameModel _gameModel;
    private PointModel _pointModel;

    private GameObject _playerGameObject;
    private PlayerController _playerController;
    private InputHandler _inputHandler;
    private GameObject[] _bulletsList;
    
    private ILevelManager _levelManager;
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

    public void ChancheView()
    {
        /*_levelManager.ChangeAllView();*/
        _gameModel.ChangeViewMode();
    }

    private void Awake()
    {
        ModelFactory.RegisterEnemies();
        ControllerFactory.RegisterControllers();
        ShellControllerFactory.RegisterControllers();
        ShellModelFactory.RegisterEnemies();
        
        
        _pointModel = new PointModel(0);
        _inputHandler = new InputHandler();
        _inputHandler.Awake();
        _player = new Player(_levelInfo.GetPlayerInfo());

        _levelModel = new LevelModel(_levelInfo, _player);
        _levelManager = new LevelManager();
        _levelManager.SetLevel(_levelModel);
        _gameModel = _levelModel.GameModel;
        _levelController = new LevelController(_pointModel, _levelManager);
        _playerController = new PlayerController(_levelModel.CurrentPlayer, _inputHandler, _levelManager);
        
        _playerController.Start();
        _levelController.Start();
        _uiController.Init(_pointModel, _gameModel);
        
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
