using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class PlayerInputHandler : SingletonBehaviour<PlayerInputHandler>
{
    public event Action<Vector2> OnMove;
    public event Action OnJump;
    public event Action<Vector2> OnLook;
    public event Action OnFire;
    public event Action OnSwitchWeapon;

    private PlayerInputActions inputActions;

    protected override void Awake()
    {
        base.Awake();
        inputActions = new PlayerInputActions();

        inputActions.Gameplay.Move.performed += ctx => OnMove?.Invoke(ctx.ReadValue<Vector2>());
        inputActions.Gameplay.Move.canceled  += ctx => OnMove?.Invoke(Vector2.zero);
        inputActions.Gameplay.Jump.performed += ctx => OnJump?.Invoke();
        inputActions.Gameplay.Look.performed  += ctx => OnLook?.Invoke(ctx.ReadValue<Vector2>());
        inputActions.Gameplay.Fire.performed  += ctx => OnFire?.Invoke();
        inputActions.Gameplay.SwitchWeapon.performed += ctx => OnSwitchWeapon?.Invoke();
    }

    private void OnEnable() => inputActions.Enable();
    private void OnDisable() => inputActions.Disable();
}