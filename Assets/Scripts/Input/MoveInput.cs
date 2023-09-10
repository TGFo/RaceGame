using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveInput : MonoBehaviour
{
    public Vector2 inputMove { get; private set; } = Vector2.zero;

    InputActions input = null;

    private void OnEnable()
    {
        input = new InputActions();
        input.Move.Enable();

        input.Move.Movement.performed += SetMove;
        input.Move.Movement.canceled += SetMove;
    }

    private void OnDisable()
    {
        input.Move.Movement.performed -= SetMove;
        input.Move.Movement.canceled -= SetMove;

        input.Move.Disable();
    }

    private void SetMove(InputAction.CallbackContext ctx)
    {
        inputMove = ctx.ReadValue<Vector2>();
        //Debug.Log("input vector:" + inputMove.ToString());
    }

}
