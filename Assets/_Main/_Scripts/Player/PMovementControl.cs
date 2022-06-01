using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PMovementControl : MonoBehaviour
{
    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float verticalSpeed;

    private PlayerInput playerInput;
    private InputAction inputAction;
    private Rigidbody rigidBody;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        rigidBody = GetComponent<Rigidbody>();
        inputAction = playerInput.actions["Movement"];
    }

    void FixedUpdate()
    {
        Move();
    }
    
    private void Move()
    {
        rigidBody.MovePosition(transform.position + MovementInput());
    }

    private Vector3 MovementInput()
    {
        Vector2 input = inputAction.ReadValue<Vector2>();
        float hor = input.x * verticalSpeed * Time.fixedDeltaTime;
        float ver = horizontalSpeed * Time.fixedDeltaTime;

        return new Vector3(hor, 0, ver);
    }
}