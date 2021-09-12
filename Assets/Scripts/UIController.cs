using Asteroids.Model;
using UnityEngine;
using UnityEngine.UI;
using Zenject;


    public class UIController : MonoBehaviour
    {
        [Inject] private PointModel _pointModel;
        [Inject] private GameModel _gameModel;
        
        [SerializeField] private GameObject _restartButton;
        [SerializeField] private GameObject _totalScore;
        [SerializeField] private GameObject _guiScore;
        
        private Text _scoreTextCounter;
        
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

        private void Detach()
        {
            _gameModel.GameRestarted -= GameRestarted;
            _pointModel.ResourceValueChanged -= ChangePoints;
            _gameModel.GameEnded -= OnGameEnd;
        }
        
        private void Attach()
        {
            _gameModel.GameRestarted += GameRestarted;
            _pointModel.ResourceValueChanged += ChangePoints;
            _gameModel.GameEnded += OnGameEnd;
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

        private void OnDestroy()
        {
            Detach();
        }
    }
