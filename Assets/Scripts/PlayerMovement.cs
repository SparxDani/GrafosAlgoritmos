using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private PlayerMovementMap inputActions;
    private Vector2 moveInput;
    private Rigidbody2D rb;


    private void Awake()
    {
        inputActions = new PlayerMovementMap();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        inputActions.Enable();
        inputActions.Player.Movement.performed += Movement_performed;
        inputActions.Player.Movement.canceled += Movement_canceled;
    }
    private void OnDisable()
    {
        inputActions.Disable();
        inputActions.Player.Movement.performed -= Movement_performed;
        inputActions.Player.Movement.canceled -= Movement_canceled;
    }

    private void Movement_performed(InputAction.CallbackContext obj)
    {
        moveInput = obj.ReadValue<Vector2>();
    }
    private void Movement_canceled(InputAction.CallbackContext obj)
    {
        moveInput = Vector2.zero;
    }
    

    private void FixedUpdate()
    {
        rb.velocity = moveInput * moveSpeed;
    }
}
