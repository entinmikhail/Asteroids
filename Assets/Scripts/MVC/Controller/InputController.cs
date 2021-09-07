using System;
using Asteroids.Abstraction;
using Asteroids.Input;

namespace Asteroids.Controller
{
    public class InputHandler : IUpdatable, IInputHandler
    {
        private PlayerInput _input;

        
        public event Action Fire1Clicked;
        public event Action Fire2Clicked;
        public event Action<float> MoveClicked;
        public event Action<float> RotationClicked;
            
        public void Awake()
        {
            _input = new PlayerInput();
            
            OnAwake();
        }
        
        public void Update(double deltaTime)
        {
            MoveClicked?.Invoke(_input.Player.Move.ReadValue<float>());
            RotationClicked?.Invoke(_input.Player.Rotation.ReadValue<float>());
        }
        
        private void OnAwake()
        {
            OnEnable();
            
            _input.Player.Enable();
        
            _input.Player.Fire1.Enable();
            _input.Player.Fire2.Enable();
        
            _input.Player.Move.Enable();
            _input.Player.Rotation.Enable();
        
            _input.Player.Fire1.performed += _ => Fire1();
            _input.Player.Fire2.performed += _ => Fire2();
        }

        private void Fire1()
        {
            Fire1Clicked?.Invoke();
        }
        private void Fire2()
        {
            Fire2Clicked?.Invoke();
        }
        
        public void OnEnable()
        {
            _input.Enable();
        }
        
        public void OnDisable()
        {
            _input.Disable();
        }
    }
}