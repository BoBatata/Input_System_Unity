//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.3
//     from Assets/Scripts/Input_System/CharacterControl.inputactions
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

public partial class @CharacterControl: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @CharacterControl()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""CharacterControl"",
    ""maps"": [
        {
            ""name"": ""PlayerBehaviour"",
            ""id"": ""38b0dfcc-9f82-4039-87fb-732d12dd9309"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""6c72bd40-796f-4973-bd84-cecf11bf080e"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""9cc62c3f-bb05-4722-afd1-134815cabc43"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9fa84c3a-8cfb-42e8-844f-ffb87bd8e138"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""[Keyboard] AD"",
                    ""id"": ""d1da6ae2-6a23-46f1-9e56-ee837c5e6666"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""bf6d42ef-3a73-4051-aaf2-8838276f6c22"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""1ca9be1e-fa0f-4ab8-87c5-352c15b4efde"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""0f9d2568-a71e-4506-bc0b-e4c72eed35d2"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ba81b07f-fd7b-4c3c-956c-f7658638ecbc"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerBehaviour
        m_PlayerBehaviour = asset.FindActionMap("PlayerBehaviour", throwIfNotFound: true);
        m_PlayerBehaviour_Move = m_PlayerBehaviour.FindAction("Move", throwIfNotFound: true);
        m_PlayerBehaviour_Jump = m_PlayerBehaviour.FindAction("Jump", throwIfNotFound: true);
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

    // PlayerBehaviour
    private readonly InputActionMap m_PlayerBehaviour;
    private List<IPlayerBehaviourActions> m_PlayerBehaviourActionsCallbackInterfaces = new List<IPlayerBehaviourActions>();
    private readonly InputAction m_PlayerBehaviour_Move;
    private readonly InputAction m_PlayerBehaviour_Jump;
    public struct PlayerBehaviourActions
    {
        private @CharacterControl m_Wrapper;
        public PlayerBehaviourActions(@CharacterControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_PlayerBehaviour_Move;
        public InputAction @Jump => m_Wrapper.m_PlayerBehaviour_Jump;
        public InputActionMap Get() { return m_Wrapper.m_PlayerBehaviour; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerBehaviourActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerBehaviourActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerBehaviourActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerBehaviourActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
        }

        private void UnregisterCallbacks(IPlayerBehaviourActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
        }

        public void RemoveCallbacks(IPlayerBehaviourActions instance)
        {
            if (m_Wrapper.m_PlayerBehaviourActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerBehaviourActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerBehaviourActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerBehaviourActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerBehaviourActions @PlayerBehaviour => new PlayerBehaviourActions(this);
    public interface IPlayerBehaviourActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
    }
}
