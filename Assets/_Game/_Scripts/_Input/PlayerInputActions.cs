//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/_Game/_Scripts/_Input/PlayerInputActions.inputactions
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

public partial class @PlayerInputActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""pActionMap"",
            ""id"": ""bb4a6398-411a-4e0e-9842-45f63655bcdf"",
            ""actions"": [
                {
                    ""name"": ""MouseLook"",
                    ""type"": ""Value"",
                    ""id"": ""18f5f67a-26d9-4f3d-9cd4-7f132e0547b5"",
                    ""expectedControlType"": ""Delta"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""275bf140-7a62-446d-9dd6-e59824d45f04"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""716a1602-f2cd-4023-ad0c-21bbc202c11d"",
                    ""path"": ""<Pointer>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseLook"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""73b28581-e786-452f-b688-09e2b33aa129"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // pActionMap
        m_pActionMap = asset.FindActionMap("pActionMap", throwIfNotFound: true);
        m_pActionMap_MouseLook = m_pActionMap.FindAction("MouseLook", throwIfNotFound: true);
        m_pActionMap_Fire = m_pActionMap.FindAction("Fire", throwIfNotFound: true);
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

    // pActionMap
    private readonly InputActionMap m_pActionMap;
    private List<IPActionMapActions> m_PActionMapActionsCallbackInterfaces = new List<IPActionMapActions>();
    private readonly InputAction m_pActionMap_MouseLook;
    private readonly InputAction m_pActionMap_Fire;
    public struct PActionMapActions
    {
        private @PlayerInputActions m_Wrapper;
        public PActionMapActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @MouseLook => m_Wrapper.m_pActionMap_MouseLook;
        public InputAction @Fire => m_Wrapper.m_pActionMap_Fire;
        public InputActionMap Get() { return m_Wrapper.m_pActionMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PActionMapActions set) { return set.Get(); }
        public void AddCallbacks(IPActionMapActions instance)
        {
            if (instance == null || m_Wrapper.m_PActionMapActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PActionMapActionsCallbackInterfaces.Add(instance);
            @MouseLook.started += instance.OnMouseLook;
            @MouseLook.performed += instance.OnMouseLook;
            @MouseLook.canceled += instance.OnMouseLook;
            @Fire.started += instance.OnFire;
            @Fire.performed += instance.OnFire;
            @Fire.canceled += instance.OnFire;
        }

        private void UnregisterCallbacks(IPActionMapActions instance)
        {
            @MouseLook.started -= instance.OnMouseLook;
            @MouseLook.performed -= instance.OnMouseLook;
            @MouseLook.canceled -= instance.OnMouseLook;
            @Fire.started -= instance.OnFire;
            @Fire.performed -= instance.OnFire;
            @Fire.canceled -= instance.OnFire;
        }

        public void RemoveCallbacks(IPActionMapActions instance)
        {
            if (m_Wrapper.m_PActionMapActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPActionMapActions instance)
        {
            foreach (var item in m_Wrapper.m_PActionMapActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PActionMapActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PActionMapActions @pActionMap => new PActionMapActions(this);
    public interface IPActionMapActions
    {
        void OnMouseLook(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
    }
}
