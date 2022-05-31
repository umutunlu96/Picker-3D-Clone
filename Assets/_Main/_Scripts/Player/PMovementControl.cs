using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PMovementControl : MonoBehaviour
{
    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float verticalSpeed;

    private PlayerInput _playerInput;
    private InputAction _moveAction;
    private Rigidbody _rb;


    private void Awake()
    {

        _playerInput = GetComponent<PlayerInput>();
        _moveAction = _playerInput.actions["Movement"];
        _rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector2 input = _moveAction.ReadValue<Vector2>();
        _rb.MovePosition(transform.position + new Vector3(input.x * Time.deltaTime, 0, verticalSpeed * Time.deltaTime));
    }

    public void setVerticalSpeed(float newVerticalSpeed)
    {
        verticalSpeed = newVerticalSpeed;
    }
    public float getVerticalSpeed()
    {
        return verticalSpeed;
    }
}