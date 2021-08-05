// GENERATED AUTOMATICALLY FROM 'Assets/Configs/PlayerInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Asteroids.Input
{
    public class @PlayerInput : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }

        public @PlayerInput()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""9c2f5978-57db-45e2-b355-704aaad57f2a"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""0eb12a16-da6e-4e00-b3f4-26645b164cac"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotation"",
                    ""type"": ""Button"",
                    ""id"": ""fd095da3-a0e6-47f5-adee-a48c3c5b6371"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire1"",
                    ""type"": ""Button"",
                    ""id"": ""b6fd1328-49fb-4aa4-be51-26570b509294"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire2"",
                    ""type"": ""Button"",
                    ""id"": ""66ef44d2-73ff-4ad9-8171-98e9a5cc6ce5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""bf8a771c-194f-46c1-b5b0-35dc1c67d43c"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""07baae8f-8ae4-4fc8-87da-b9e454c65336"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e1049576-5fc7-492d-9e82-8d2ceeed3df7"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""e7eab77c-c458-4702-b354-9df37a50152a"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""8764e43c-3a07-46dd-b77d-9ce8f41990ce"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""ce6c4f02-5de0-406c-9f92-a0eddca3ecfd"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Player
            m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
            m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
            m_Player_Rotation = m_Player.FindAction("Rotation", throwIfNotFound: true);
            m_Player_Fire1 = m_Player.FindAction("Fire1", throwIfNotFound: true);
            m_Player_Fire2 = m_Player.FindAction("Fire2", throwIfNotFound: true);
        }

        public void Dispose()
        {
            UnityEngine.Object.Destroy(asset);
        }

        public InputBinding? bindingMask
        {
            get => asset.bindingMask;
            set => asset.bindingMask = value;
        }

        public ReadOnlyArray<InputDevice>? devices
        {
            get => asset.devices;
            set => asset.devices = value;
        }

        public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

        public bool Contains(InputAction action)
        {
            return asset.Contains(action);
        }

        public IEnumerator<InputAction> GetEnumerator()
        {
            return asset.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Enable()
        {
            asset.Enable();
        }

        public void Disable()
        {
            asset.Disable();
        }

        // Player
        private readonly InputActionMap m_Player;
        private IPlayerActions m_PlayerActionsCallbackInterface;
        private readonly InputAction m_Player_Move;
        private readonly InputAction m_Player_Rotation;
        private readonly InputAction m_Player_Fire1;
        private readonly InputAction m_Player_Fire2;

        public struct PlayerActions
        {
            private @PlayerInput m_Wrapper;

            public PlayerActions(@PlayerInput wrapper)
            {
                m_Wrapper = wrapper;
            }

            public InputAction @Move => m_Wrapper.m_Player_Move;
            public InputAction @Rotation => m_Wrapper.m_Player_Rotation;
            public InputAction @Fire1 => m_Wrapper.m_Player_Fire1;
            public InputAction @Fire2 => m_Wrapper.m_Player_Fire2;

            public InputActionMap Get()
            {
                return m_Wrapper.m_Player;
            }

            public void Enable()
            {
                Get().Enable();
            }

            public void Disable()
            {
                Get().Disable();
            }

            public bool enabled => Get().enabled;

            public static implicit operator InputActionMap(PlayerActions set)
            {
                return set.Get();
            }

            public void SetCallbacks(IPlayerActions instance)
            {
                if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
                {
                    @Move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                    @Move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                    @Move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                    @Rotation.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotation;
                    @Rotation.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotation;
                    @Rotation.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotation;
                    @Fire1.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFire1;
                    @Fire1.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFire1;
                    @Fire1.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFire1;
                    @Fire2.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFire2;
                    @Fire2.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFire2;
                    @Fire2.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFire2;
                }

                m_Wrapper.m_PlayerActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Move.started += instance.OnMove;
                    @Move.performed += instance.OnMove;
                    @Move.canceled += instance.OnMove;
                    @Rotation.started += instance.OnRotation;
                    @Rotation.performed += instance.OnRotation;
                    @Rotation.canceled += instance.OnRotation;
                    @Fire1.started += instance.OnFire1;
                    @Fire1.performed += instance.OnFire1;
                    @Fire1.canceled += instance.OnFire1;
                    @Fire2.started += instance.OnFire2;
                    @Fire2.performed += instance.OnFire2;
                    @Fire2.canceled += instance.OnFire2;
                }
            }
        }

        public PlayerActions @Player => new PlayerActions(this);

        public interface IPlayerActions
        {
            void OnMove(InputAction.CallbackContext context);
            void OnRotation(InputAction.CallbackContext context);
            void OnFire1(InputAction.CallbackContext context);
            void OnFire2(InputAction.CallbackContext context);
        }
    }
}