// GENERATED AUTOMATICALLY FROM 'Assets/PlayerActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerActions"",
    ""maps"": [
        {
            ""name"": ""Spaceship"",
            ""id"": ""9ce83964-38c1-47db-9ae4-5a197d34e6a6"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""d03dac3b-b95b-4e82-ae73-844ab18e8386"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ShootBullet"",
                    ""type"": ""Button"",
                    ""id"": ""1542246e-6fb9-48d2-b615-a8f915ea03f2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ShootLaser"",
                    ""type"": ""Button"",
                    ""id"": ""41060ba6-d555-4423-9464-add741f90450"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""ae1b7ce7-a4c5-46f5-8c2f-705543126879"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""f1c81023-6ed3-4018-8034-eb5d12aee813"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseKeyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""1b5c6867-3811-4900-bc19-0442fe0f939f"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseKeyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""55558e58-fde5-4fda-8b0a-76c52cde88a9"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseKeyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""9f867e2f-d7be-4363-9896-b7f65dbf2ea3"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseKeyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""8cdb95ea-540b-4056-898b-bea658e6db90"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""29c070f7-1368-46d1-aabe-493326e26457"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardOnly"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""b5a46c26-c019-43b8-a883-f5b33dd043d4"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardOnly"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""0572b70f-677f-496f-aca7-6aca59e068b3"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardOnly"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""df82faef-4103-4d90-a66b-c49f8b98ecaa"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardOnly"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""30fb9feb-3155-4e96-bf4f-5416b060cb57"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseKeyboard"",
                    ""action"": ""ShootBullet"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1bfa4c72-e8e2-431f-afe3-e9b4340983bc"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardOnly"",
                    ""action"": ""ShootBullet"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""161c6a7b-ee86-46d0-a086-6dc1537c79a2"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseKeyboard"",
                    ""action"": ""ShootLaser"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e037d2e3-b6bb-4f3b-9d99-58f1f190506d"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardOnly"",
                    ""action"": ""ShootLaser"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""MouseKeyboard"",
            ""bindingGroup"": ""MouseKeyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""KeyboardOnly"",
            ""bindingGroup"": ""KeyboardOnly"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Spaceship
        m_Spaceship = asset.FindActionMap("Spaceship", throwIfNotFound: true);
        m_Spaceship_Movement = m_Spaceship.FindAction("Movement", throwIfNotFound: true);
        m_Spaceship_ShootBullet = m_Spaceship.FindAction("ShootBullet", throwIfNotFound: true);
        m_Spaceship_ShootLaser = m_Spaceship.FindAction("ShootLaser", throwIfNotFound: true);
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

    // Spaceship
    private readonly InputActionMap m_Spaceship;
    private ISpaceshipActions m_SpaceshipActionsCallbackInterface;
    private readonly InputAction m_Spaceship_Movement;
    private readonly InputAction m_Spaceship_ShootBullet;
    private readonly InputAction m_Spaceship_ShootLaser;
    public struct SpaceshipActions
    {
        private @PlayerActions m_Wrapper;
        public SpaceshipActions(@PlayerActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Spaceship_Movement;
        public InputAction @ShootBullet => m_Wrapper.m_Spaceship_ShootBullet;
        public InputAction @ShootLaser => m_Wrapper.m_Spaceship_ShootLaser;
        public InputActionMap Get() { return m_Wrapper.m_Spaceship; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SpaceshipActions set) { return set.Get(); }
        public void SetCallbacks(ISpaceshipActions instance)
        {
            if (m_Wrapper.m_SpaceshipActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_SpaceshipActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_SpaceshipActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_SpaceshipActionsCallbackInterface.OnMovement;
                @ShootBullet.started -= m_Wrapper.m_SpaceshipActionsCallbackInterface.OnShootBullet;
                @ShootBullet.performed -= m_Wrapper.m_SpaceshipActionsCallbackInterface.OnShootBullet;
                @ShootBullet.canceled -= m_Wrapper.m_SpaceshipActionsCallbackInterface.OnShootBullet;
                @ShootLaser.started -= m_Wrapper.m_SpaceshipActionsCallbackInterface.OnShootLaser;
                @ShootLaser.performed -= m_Wrapper.m_SpaceshipActionsCallbackInterface.OnShootLaser;
                @ShootLaser.canceled -= m_Wrapper.m_SpaceshipActionsCallbackInterface.OnShootLaser;
            }
            m_Wrapper.m_SpaceshipActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @ShootBullet.started += instance.OnShootBullet;
                @ShootBullet.performed += instance.OnShootBullet;
                @ShootBullet.canceled += instance.OnShootBullet;
                @ShootLaser.started += instance.OnShootLaser;
                @ShootLaser.performed += instance.OnShootLaser;
                @ShootLaser.canceled += instance.OnShootLaser;
            }
        }
    }
    public SpaceshipActions @Spaceship => new SpaceshipActions(this);
    private int m_MouseKeyboardSchemeIndex = -1;
    public InputControlScheme MouseKeyboardScheme
    {
        get
        {
            if (m_MouseKeyboardSchemeIndex == -1) m_MouseKeyboardSchemeIndex = asset.FindControlSchemeIndex("MouseKeyboard");
            return asset.controlSchemes[m_MouseKeyboardSchemeIndex];
        }
    }
    private int m_KeyboardOnlySchemeIndex = -1;
    public InputControlScheme KeyboardOnlyScheme
    {
        get
        {
            if (m_KeyboardOnlySchemeIndex == -1) m_KeyboardOnlySchemeIndex = asset.FindControlSchemeIndex("KeyboardOnly");
            return asset.controlSchemes[m_KeyboardOnlySchemeIndex];
        }
    }
    public interface ISpaceshipActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnShootBullet(InputAction.CallbackContext context);
        void OnShootLaser(InputAction.CallbackContext context);
    }
}
