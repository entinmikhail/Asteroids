using System.Net.Mime;
using Asteroids.Abstraction;
using Asteroids.Model;
using UnityEngine;
using UnityEngine.UI;


public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject _restartButton;
    [SerializeField] private GameObject _totalScore;
    [SerializeField] private GameObject _guiScore;
    [SerializeField] private Button _changeViewClick;
    
    private PointModel _pointModel;
    private IGameModel _gameModel;
    
    private Text _scoreTextCounter;

    public void Init(PointModel pointModel, IGameModel gameModel )
    {
        _pointModel = pointModel;
        _gameModel = gameModel;
    }
    
    public void Start()
    {
        Attach();

        _scoreTextCounter = _guiScore.GetComponent<Text>();
        
        GameRestarted();
    }

    private void OnGameEnd()
    {
        UiSetActive(true);
        _totalScore.GetComponent<Text>().text = $"Total score: {_pointModel.GetCurrentResourceValue()}";
    }
    
    private void GameRestarted()
    {
        UiSetActive(false);
    }
    
    private void UiSetActive(bool value)
    {
        _guiScore.SetActive(!value);
        _restartButton.SetActive(value); 
        _totalScore.SetActive(value);
    }
    
    private void ChangePoints(float curvalue, float prevvalue)
    {
        _scoreTextCounter.text = curvalue.ToString();
    }
    
    private void OnChangeViewClick()
    {
        _gameModel.ChangeViewMode();
    }
    
    private void Detach()
    {
        _changeViewClick.onClick.RemoveListener(OnChangeViewClick);
        _gameModel.GameRestarted -= GameRestarted;
        _pointModel.ResourceValueChanged -= ChangePoints;
        _gameModel.GameEnded -= OnGameEnd;
    }
    
    private void Attach()
    {
        _changeViewClick.onClick.AddListener(OnChangeViewClick);
        _gameModel.GameRestarted += GameRestarted;
        _pointModel.ResourceValueChanged += ChangePoints;
        _gameModel.GameEnded += OnGameEnd;
    }
    
    private void OnDestroy()
    {
        Detach();
    }
}
