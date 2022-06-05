using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class StartGameKey : MonoBehaviour
{
    public static Action OnStartButtonPressed;

    private PlayerInput playerInput;
    private InputAction inputAction;

    private bool isGameStarted = false;

    private void Awake()
    {
        isGameStarted = false;
        playerInput = GetComponent<PlayerInput>();
        inputAction = playerInput.actions["Start"];
    }

    private void Update()
    {
        if (inputAction.IsPressed() && !isGameStarted)
        {
            OnStartButtonPressed?.Invoke();
            isGameStarted = true;
        }
    }
}