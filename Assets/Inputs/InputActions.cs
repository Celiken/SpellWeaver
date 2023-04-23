//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.1
//     from Assets/Inputs/InputActions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @InputActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""0ec3c949-b894-4d80-8378-6569f55e3cbe"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""3852e743-a493-474c-bd84-8668e4710b9f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Button"",
                    ""id"": ""a0c42d4a-135c-4055-956c-a751ef403802"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""7ba79cb5-58e8-4451-93e7-24ba265ee77e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Spell 1"",
                    ""type"": ""Button"",
                    ""id"": ""a113e3e9-2660-4616-8742-82c0dd30c9da"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Spell 2"",
                    ""type"": ""Button"",
                    ""id"": ""12c2adff-90cb-4069-9f87-8b2e75fef1eb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Spell 3"",
                    ""type"": ""Button"",
                    ""id"": ""235db95b-306f-4d29-9708-83cad150174d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Spell 4"",
                    ""type"": ""Button"",
                    ""id"": ""5b8b346f-ed77-4639-a854-f7e0c5f6b26b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Spell 5"",
                    ""type"": ""Button"",
                    ""id"": ""1f08b4ec-ee75-46a3-a4d0-b55c6f22b55f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Spell 6"",
                    ""type"": ""Button"",
                    ""id"": ""f2a32b32-bdfc-4526-bc8e-2fa1ab14faef"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""abf32d21-9d04-4a71-b66e-d1d6e8a60b61"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9a33ced5-4a5f-4efb-94f1-743dd0f2547f"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Spell 1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dcd3bf43-a564-4571-b752-7bb11968d20f"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Spell 2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c93903c1-442a-4616-9c5c-742d4c8a0975"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Spell 3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""80821df4-d989-479e-af97-9bcfd1e54124"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Spell 4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""00001e0e-cce7-46f1-8a5f-962a4a305202"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Spell 5"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""befee56b-b243-4692-adff-5890b066cb4b"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cb8fd44d-aa9d-47ae-8bb5-827d75409e56"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Spell 6"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""59a0c76c-f71c-43f1-bcbc-b13f8b3283d6"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
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
        m_Player_Aim = m_Player.FindAction("Aim", throwIfNotFound: true);
        m_Player_Dash = m_Player.FindAction("Dash", throwIfNotFound: true);
        m_Player_Spell1 = m_Player.FindAction("Spell 1", throwIfNotFound: true);
        m_Player_Spell2 = m_Player.FindAction("Spell 2", throwIfNotFound: true);
        m_Player_Spell3 = m_Player.FindAction("Spell 3", throwIfNotFound: true);
        m_Player_Spell4 = m_Player.FindAction("Spell 4", throwIfNotFound: true);
        m_Player_Spell5 = m_Player.FindAction("Spell 5", throwIfNotFound: true);
        m_Player_Spell6 = m_Player.FindAction("Spell 6", throwIfNotFound: true);
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Player
    private readonly InputActionMap m_Player;
    private List<IPlayerActions> m_PlayerActionsCallbackInterfaces = new List<IPlayerActions>();
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_Aim;
    private readonly InputAction m_Player_Dash;
    private readonly InputAction m_Player_Spell1;
    private readonly InputAction m_Player_Spell2;
    private readonly InputAction m_Player_Spell3;
    private readonly InputAction m_Player_Spell4;
    private readonly InputAction m_Player_Spell5;
    private readonly InputAction m_Player_Spell6;
    public struct PlayerActions
    {
        private @InputActions m_Wrapper;
        public PlayerActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @Aim => m_Wrapper.m_Player_Aim;
        public InputAction @Dash => m_Wrapper.m_Player_Dash;
        public InputAction @Spell1 => m_Wrapper.m_Player_Spell1;
        public InputAction @Spell2 => m_Wrapper.m_Player_Spell2;
        public InputAction @Spell3 => m_Wrapper.m_Player_Spell3;
        public InputAction @Spell4 => m_Wrapper.m_Player_Spell4;
        public InputAction @Spell5 => m_Wrapper.m_Player_Spell5;
        public InputAction @Spell6 => m_Wrapper.m_Player_Spell6;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Aim.started += instance.OnAim;
            @Aim.performed += instance.OnAim;
            @Aim.canceled += instance.OnAim;
            @Dash.started += instance.OnDash;
            @Dash.performed += instance.OnDash;
            @Dash.canceled += instance.OnDash;
            @Spell1.started += instance.OnSpell1;
            @Spell1.performed += instance.OnSpell1;
            @Spell1.canceled += instance.OnSpell1;
            @Spell2.started += instance.OnSpell2;
            @Spell2.performed += instance.OnSpell2;
            @Spell2.canceled += instance.OnSpell2;
            @Spell3.started += instance.OnSpell3;
            @Spell3.performed += instance.OnSpell3;
            @Spell3.canceled += instance.OnSpell3;
            @Spell4.started += instance.OnSpell4;
            @Spell4.performed += instance.OnSpell4;
            @Spell4.canceled += instance.OnSpell4;
            @Spell5.started += instance.OnSpell5;
            @Spell5.performed += instance.OnSpell5;
            @Spell5.canceled += instance.OnSpell5;
            @Spell6.started += instance.OnSpell6;
            @Spell6.performed += instance.OnSpell6;
            @Spell6.canceled += instance.OnSpell6;
        }

        private void UnregisterCallbacks(IPlayerActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Aim.started -= instance.OnAim;
            @Aim.performed -= instance.OnAim;
            @Aim.canceled -= instance.OnAim;
            @Dash.started -= instance.OnDash;
            @Dash.performed -= instance.OnDash;
            @Dash.canceled -= instance.OnDash;
            @Spell1.started -= instance.OnSpell1;
            @Spell1.performed -= instance.OnSpell1;
            @Spell1.canceled -= instance.OnSpell1;
            @Spell2.started -= instance.OnSpell2;
            @Spell2.performed -= instance.OnSpell2;
            @Spell2.canceled -= instance.OnSpell2;
            @Spell3.started -= instance.OnSpell3;
            @Spell3.performed -= instance.OnSpell3;
            @Spell3.canceled -= instance.OnSpell3;
            @Spell4.started -= instance.OnSpell4;
            @Spell4.performed -= instance.OnSpell4;
            @Spell4.canceled -= instance.OnSpell4;
            @Spell5.started -= instance.OnSpell5;
            @Spell5.performed -= instance.OnSpell5;
            @Spell5.canceled -= instance.OnSpell5;
            @Spell6.started -= instance.OnSpell6;
            @Spell6.performed -= instance.OnSpell6;
            @Spell6.canceled -= instance.OnSpell6;
        }

        public void RemoveCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnSpell1(InputAction.CallbackContext context);
        void OnSpell2(InputAction.CallbackContext context);
        void OnSpell3(InputAction.CallbackContext context);
        void OnSpell4(InputAction.CallbackContext context);
        void OnSpell5(InputAction.CallbackContext context);
        void OnSpell6(InputAction.CallbackContext context);
    }
}
