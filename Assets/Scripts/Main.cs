using Asteroids.View;
using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField] private PlayerView _playerView;

    private PlayerController _playerController;
    private void Awake()
    {
        _playerController = new PlayerController(_playerView);
        _playerController.Awake();
    }

    private void Update()
    {
        _playerController.Update();
    }
}
