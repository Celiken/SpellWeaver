using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance;

    public event EventHandler OnDash;
    public event EventHandler OnAim;

    private InputActions inputActions;

    private void Awake()
    {
        Instance = this;
        inputActions = new InputActions();
        inputActions.Player.Enable();

        inputActions.Player.Dash.performed += Dash_performed;
        inputActions.Player.Aim.performed += Aim_performed;
    }

    private void Aim_performed(InputAction.CallbackContext obj)
    {
        OnAim?.Invoke(this, EventArgs.Empty);
    }

    public float GetMoveInput()
    {
        return inputActions.Player.Move.ReadValue<float>();
    }

    private void Dash_performed(InputAction.CallbackContext obj)
    {
        OnDash?.Invoke(this, EventArgs.Empty);
    }

    public InputAction GetInputActionForSpell(int spellSlot)
    {
        switch (spellSlot)
        {
            default:
            case 1:
                return inputActions.Player.Spell1;
            case 2:
                return inputActions.Player.Spell2;
            case 3:
                return inputActions.Player.Spell3;
            case 4:
                return inputActions.Player.Spell4;
        }
    }
}
