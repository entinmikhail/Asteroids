using Asteroids.Model;
using UnityEngine;
using UnityEngine.UI;
using Zenject;


public class UIController : MonoBehaviour
    {
        [Inject] private HealthModel _healthModel;
        [Inject] private PointModel _pointModel;
        [Inject] private GameModel _gameModel;
        
        [SerializeField] private GameObject _restartButton;
        [SerializeField] private GameObject _totalScore;
        [SerializeField] private GameObject _guiScore;
        
        private Text _scoreTextCounter;
        
        public void Start()
        {
            _gameModel.GameRestarted += Attach;
            _pointModel.ResourceValueChanged += ChangePoints;
            _gameModel.GameEnded += OnGameEnd;
            _scoreTextCounter = _guiScore.GetComponent<Text>();
            
            Attach();
        }

        public void Update()
        {

        }

        private void OnGameEnd()
        {
            _gameModel.GameRestarted -= Attach;
            _pointModel.ResourceValueChanged -= ChangePoints;
            _gameModel.GameEnded -= OnGameEnd;
        }
        
        private void Attach()
        {
            UiSetActive(false);
            
            _healthModel.ResourceEnded += OnPlayerDead;
        }

        private void Detach()
        {
            _healthModel.ResourceEnded -= OnPlayerDead;
        }
        
        private void UiSetActive(bool value)
        {
            _guiScore.SetActive(!value);
            _restartButton.SetActive(value); 
            _totalScore.SetActive(value);
        }
        
        private void OnPlayerDead()
        {
            UiSetActive(true);
            
            _totalScore.GetComponent<Text>().text = $"Total score: {_pointModel.GetCurrentResourceValue()}";
            
            Detach();
        }
        
        private void ChangePoints(float curvalue, float prevvalue)
        {
            _scoreTextCounter.text = curvalue.ToString();
        }
    }
