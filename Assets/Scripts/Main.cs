using Asteroids.Input;
using Asteroids.View;
using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField] private PlayerView _playerView;
    private PlayerInput _input;

    private PlayerController _playerController;
    private void Awake()
    {
        _input = new PlayerInput();
        _playerController = new PlayerController(_playerView);
        _playerController.Awake();
    }

    private void Update()
    {
        _playerController.Update();
    }
}
