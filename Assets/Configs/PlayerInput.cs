// GENERATED AUTOMATICALLY FROM 'Assets/Configs/PlayerInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

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
        },
        {
            ""name"": ""Ui"",
            ""id"": ""cb71257e-e160-497e-aa9c-09aa709ac435"",
            ""actions"": [
                {
                    ""name"": ""Navigate"",
                    ""type"": ""PassThrough"",
                    ""id"": ""e2919396-d7af-4fa3-9e22-52c03f72a83b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Submit"",
                    ""type"": ""Button"",
                    ""id"": ""85e220ef-02ef-49ef-9ea1-ae988e822b4d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""50ab0b54-bd87-4771-9d98-3d8bdde83537"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Point"",
                    ""type"": ""PassThrough"",
                    ""id"": ""611d07e3-f3a4-4760-be84-0410c0c7d91c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Click"",
                    ""type"": ""PassThrough"",
                    ""id"": ""cf128646-58d0-4dfd-b247-f8c7e99698af"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ScrollWheel"",
                    ""type"": ""PassThrough"",
                    ""id"": ""bd0acab5-119e-47c2-92aa-f8d035a62cce"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MiddleClick"",
                    ""type"": ""PassThrough"",
                    ""id"": ""1b5f91d3-5755-43f1-87ac-86904b49e7cf"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightClick"",
                    ""type"": ""PassThrough"",
                    ""id"": ""4ff4833f-6d44-4115-b75f-48ea45ff711b"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TrackedDevicePosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""e1ce98a3-1ad8-4589-a628-ea857371bfc0"",
                    ""expectedControlType"": ""Vector3"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TrackedDeviceOrientation"",
                    ""type"": ""PassThrough"",
                    ""id"": ""43349bc1-6cef-460f-9251-0727442d8803"",
                    ""expectedControlType"": ""Quaternion"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Gamepad"",
                    ""id"": ""b661b515-f5c1-4700-b390-7b84cb2e1da5"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""44707951-e65b-4393-aa60-18c1f7174260"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""f28fbe96-d884-4126-a84b-afba0b4522d5"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""021ef647-2de9-4b6a-8844-3edca64b6bfe"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""0e22607d-3f41-4c78-ba20-83f6435c2428"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""2bae6681-8552-4c11-a80a-9f0136613533"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""6b341761-98ff-4d89-92ce-f17ea2bb5496"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""f7320a94-72de-494c-9fc4-149b5a950331"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""ac595354-61dc-4a32-9462-c184f56854cd"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""ec28b09a-c43e-4190-b111-0735b540b2d9"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Joystick"",
                    ""id"": ""d78def03-0339-4276-8f14-85da00e4de4b"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""687da9d8-40cf-48cf-870d-7269a0ee8210"",
                    ""path"": ""<Joystick>/stick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""9501111e-b06d-4ce4-b93f-1a97fbed09d2"",
                    ""path"": ""<Joystick>/stick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""c86de73d-2053-491c-853e-3a02241e5520"",
                    ""path"": ""<Joystick>/stick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""1fa1334e-58c2-4ce2-aad7-26b37c9b1e94"",
                    ""path"": ""<Joystick>/stick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""5b113be4-e09f-4583-be32-5c24fedaf1bc"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""2e238d34-9c13-4f1c-8e3e-d1e24d7a5cf4"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""29dc7b80-c78b-43b2-9cf2-e02dbcad08c1"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""9e68cbb8-4992-4b85-b740-1b3355a85f00"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""4afaa6e1-fd9a-40b8-86c2-9d29e0ff6394"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""3cf15515-ae0b-40cd-9229-f9b5ed01ad33"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""fda2d5be-3926-4bf2-b063-d8e89d6db61f"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""6836150d-503e-43f3-aa80-6cc2228559e1"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""3382e4a7-7925-4bd1-bde4-e8269958cd86"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""541d43de-6a48-4cb5-8f3f-a71dace84d53"",
                    ""path"": ""*/{Submit}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eb4d85c7-bde5-42f1-905c-4ad0c906c48e"",
                    ""path"": ""*/{Cancel}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""597ea7cf-8599-42b5-be42-16975c7c6019"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e972ddf1-fbbc-4a7e-9082-e8460b858b45"",
                    ""path"": ""<Pen>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""715c9381-54f5-4789-ad67-63995657b78b"",
                    ""path"": ""<Touchscreen>/touch*/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Touch"",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""896d9ee5-5d9a-4f3a-bf67-a297af4be735"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bb0ca096-5f0a-4f6f-8846-bfc06a63eabe"",
                    ""path"": ""<Pen>/tip"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""79771c99-a4a6-42ab-a073-4ac368f9bfd6"",
                    ""path"": ""<Touchscreen>/touch*/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Touch"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8650f09d-c6d5-4d02-bab5-40af5b01bc3f"",
                    ""path"": ""<XRController>/trigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4f790652-1b66-4465-a6b5-50c2d29c323e"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""ScrollWheel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1c854536-bf8c-48a6-93e7-916b59468b9a"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""MiddleClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4e4e544d-a5b4-4f0d-ad09-57906b614dcf"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""RightClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a02cd831-1ce1-410b-ad6b-8cd8213c2278"",
                    ""path"": ""<XRController>/devicePosition"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR"",
                    ""action"": ""TrackedDevicePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""16da0b22-5ee8-4d8f-ab9d-8586fb05cd19"",
                    ""path"": ""<XRController>/deviceRotation"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR"",
                    ""action"": ""TrackedDeviceOrientation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
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
        // Ui
        m_Ui = asset.FindActionMap("Ui", throwIfNotFound: true);
        m_Ui_Navigate = m_Ui.FindAction("Navigate", throwIfNotFound: true);
        m_Ui_Submit = m_Ui.FindAction("Submit", throwIfNotFound: true);
        m_Ui_Cancel = m_Ui.FindAction("Cancel", throwIfNotFound: true);
        m_Ui_Point = m_Ui.FindAction("Point", throwIfNotFound: true);
        m_Ui_Click = m_Ui.FindAction("Click", throwIfNotFound: true);
        m_Ui_ScrollWheel = m_Ui.FindAction("ScrollWheel", throwIfNotFound: true);
        m_Ui_MiddleClick = m_Ui.FindAction("MiddleClick", throwIfNotFound: true);
        m_Ui_RightClick = m_Ui.FindAction("RightClick", throwIfNotFound: true);
        m_Ui_TrackedDevicePosition = m_Ui.FindAction("TrackedDevicePosition", throwIfNotFound: true);
        m_Ui_TrackedDeviceOrientation = m_Ui.FindAction("TrackedDeviceOrientation", throwIfNotFound: true);
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
        public PlayerActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @Rotation => m_Wrapper.m_Player_Rotation;
        public InputAction @Fire1 => m_Wrapper.m_Player_Fire1;
        public InputAction @Fire2 => m_Wrapper.m_Player_Fire2;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
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

    // Ui
    private readonly InputActionMap m_Ui;
    private IUiActions m_UiActionsCallbackInterface;
    private readonly InputAction m_Ui_Navigate;
    private readonly InputAction m_Ui_Submit;
    private readonly InputAction m_Ui_Cancel;
    private readonly InputAction m_Ui_Point;
    private readonly InputAction m_Ui_Click;
    private readonly InputAction m_Ui_ScrollWheel;
    private readonly InputAction m_Ui_MiddleClick;
    private readonly InputAction m_Ui_RightClick;
    private readonly InputAction m_Ui_TrackedDevicePosition;
    private readonly InputAction m_Ui_TrackedDeviceOrientation;
    public struct UiActions
    {
        private @PlayerInput m_Wrapper;
        public UiActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Navigate => m_Wrapper.m_Ui_Navigate;
        public InputAction @Submit => m_Wrapper.m_Ui_Submit;
        public InputAction @Cancel => m_Wrapper.m_Ui_Cancel;
        public InputAction @Point => m_Wrapper.m_Ui_Point;
        public InputAction @Click => m_Wrapper.m_Ui_Click;
        public InputAction @ScrollWheel => m_Wrapper.m_Ui_ScrollWheel;
        public InputAction @MiddleClick => m_Wrapper.m_Ui_MiddleClick;
        public InputAction @RightClick => m_Wrapper.m_Ui_RightClick;
        public InputAction @TrackedDevicePosition => m_Wrapper.m_Ui_TrackedDevicePosition;
        public InputAction @TrackedDeviceOrientation => m_Wrapper.m_Ui_TrackedDeviceOrientation;
        public InputActionMap Get() { return m_Wrapper.m_Ui; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UiActions set) { return set.Get(); }
        public void SetCallbacks(IUiActions instance)
        {
            if (m_Wrapper.m_UiActionsCallbackInterface != null)
            {
                @Navigate.started -= m_Wrapper.m_UiActionsCallbackInterface.OnNavigate;
                @Navigate.performed -= m_Wrapper.m_UiActionsCallbackInterface.OnNavigate;
                @Navigate.canceled -= m_Wrapper.m_UiActionsCallbackInterface.OnNavigate;
                @Submit.started -= m_Wrapper.m_UiActionsCallbackInterface.OnSubmit;
                @Submit.performed -= m_Wrapper.m_UiActionsCallbackInterface.OnSubmit;
                @Submit.canceled -= m_Wrapper.m_UiActionsCallbackInterface.OnSubmit;
                @Cancel.started -= m_Wrapper.m_UiActionsCallbackInterface.OnCancel;
                @Cancel.performed -= m_Wrapper.m_UiActionsCallbackInterface.OnCancel;
                @Cancel.canceled -= m_Wrapper.m_UiActionsCallbackInterface.OnCancel;
                @Point.started -= m_Wrapper.m_UiActionsCallbackInterface.OnPoint;
                @Point.performed -= m_Wrapper.m_UiActionsCallbackInterface.OnPoint;
                @Point.canceled -= m_Wrapper.m_UiActionsCallbackInterface.OnPoint;
                @Click.started -= m_Wrapper.m_UiActionsCallbackInterface.OnClick;
                @Click.performed -= m_Wrapper.m_UiActionsCallbackInterface.OnClick;
                @Click.canceled -= m_Wrapper.m_UiActionsCallbackInterface.OnClick;
                @ScrollWheel.started -= m_Wrapper.m_UiActionsCallbackInterface.OnScrollWheel;
                @ScrollWheel.performed -= m_Wrapper.m_UiActionsCallbackInterface.OnScrollWheel;
                @ScrollWheel.canceled -= m_Wrapper.m_UiActionsCallbackInterface.OnScrollWheel;
                @MiddleClick.started -= m_Wrapper.m_UiActionsCallbackInterface.OnMiddleClick;
                @MiddleClick.performed -= m_Wrapper.m_UiActionsCallbackInterface.OnMiddleClick;
                @MiddleClick.canceled -= m_Wrapper.m_UiActionsCallbackInterface.OnMiddleClick;
                @RightClick.started -= m_Wrapper.m_UiActionsCallbackInterface.OnRightClick;
                @RightClick.performed -= m_Wrapper.m_UiActionsCallbackInterface.OnRightClick;
                @RightClick.canceled -= m_Wrapper.m_UiActionsCallbackInterface.OnRightClick;
                @TrackedDevicePosition.started -= m_Wrapper.m_UiActionsCallbackInterface.OnTrackedDevicePosition;
                @TrackedDevicePosition.performed -= m_Wrapper.m_UiActionsCallbackInterface.OnTrackedDevicePosition;
                @TrackedDevicePosition.canceled -= m_Wrapper.m_UiActionsCallbackInterface.OnTrackedDevicePosition;
                @TrackedDeviceOrientation.started -= m_Wrapper.m_UiActionsCallbackInterface.OnTrackedDeviceOrientation;
                @TrackedDeviceOrientation.performed -= m_Wrapper.m_UiActionsCallbackInterface.OnTrackedDeviceOrientation;
                @TrackedDeviceOrientation.canceled -= m_Wrapper.m_UiActionsCallbackInterface.OnTrackedDeviceOrientation;
            }
            m_Wrapper.m_UiActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Navigate.started += instance.OnNavigate;
                @Navigate.performed += instance.OnNavigate;
                @Navigate.canceled += instance.OnNavigate;
                @Submit.started += instance.OnSubmit;
                @Submit.performed += instance.OnSubmit;
                @Submit.canceled += instance.OnSubmit;
                @Cancel.started += instance.OnCancel;
                @Cancel.performed += instance.OnCancel;
                @Cancel.canceled += instance.OnCancel;
                @Point.started += instance.OnPoint;
                @Point.performed += instance.OnPoint;
                @Point.canceled += instance.OnPoint;
                @Click.started += instance.OnClick;
                @Click.performed += instance.OnClick;
                @Click.canceled += instance.OnClick;
                @ScrollWheel.started += instance.OnScrollWheel;
                @ScrollWheel.performed += instance.OnScrollWheel;
                @ScrollWheel.canceled += instance.OnScrollWheel;
                @MiddleClick.started += instance.OnMiddleClick;
                @MiddleClick.performed += instance.OnMiddleClick;
                @MiddleClick.canceled += instance.OnMiddleClick;
                @RightClick.started += instance.OnRightClick;
                @RightClick.performed += instance.OnRightClick;
                @RightClick.canceled += instance.OnRightClick;
                @TrackedDevicePosition.started += instance.OnTrackedDevicePosition;
                @TrackedDevicePosition.performed += instance.OnTrackedDevicePosition;
                @TrackedDevicePosition.canceled += instance.OnTrackedDevicePosition;
                @TrackedDeviceOrientation.started += instance.OnTrackedDeviceOrientation;
                @TrackedDeviceOrientation.performed += instance.OnTrackedDeviceOrientation;
                @TrackedDeviceOrientation.canceled += instance.OnTrackedDeviceOrientation;
            }
        }
    }
    public UiActions @Ui => new UiActions(this);
    public interface IPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnRotation(InputAction.CallbackContext context);
        void OnFire1(InputAction.CallbackContext context);
        void OnFire2(InputAction.CallbackContext context);
    }
    public interface IUiActions
    {
        void OnNavigate(InputAction.CallbackContext context);
        void OnSubmit(InputAction.CallbackContext context);
        void OnCancel(InputAction.CallbackContext context);
        void OnPoint(InputAction.CallbackContext context);
        void OnClick(InputAction.CallbackContext context);
        void OnScrollWheel(InputAction.CallbackContext context);
        void OnMiddleClick(InputAction.CallbackContext context);
        void OnRightClick(InputAction.CallbackContext context);
        void OnTrackedDevicePosition(InputAction.CallbackContext context);
        void OnTrackedDeviceOrientation(InputAction.CallbackContext context);
    }
}
