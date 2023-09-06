using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private CharacterControl characterControls;
    private Transform playerTransform;
    private Vector2 moveDirection;

    [SerializeField] private float velocity = 10;

    private void Awake()
    {
        playerTransform = GetComponent<Transform>();
        characterControls = new CharacterControl();

        characterControls.PlayerBehaviour.Move.started += OnMoveInputReceived;
        characterControls.PlayerBehaviour.Move.canceled += OnMoveInputReceived;
        characterControls.PlayerBehaviour.Move.performed += OnMoveInputReceived;

    }

    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        playerTransform.Translate(new Vector2(moveDirection.x, moveDirection.y) * velocity * Time.deltaTime);
    }

    private void OnMoveInputReceived(InputAction.CallbackContext context)
    {
        moveDirection = context.ReadValue<Vector2>();
    }

    private void OnEnable()
    {
        characterControls.Enable();
    }

    private void OnDisable()
    {
        characterControls.PlayerBehaviour.Move.started -= OnMoveInputReceived;
        characterControls.PlayerBehaviour.Move.canceled -= OnMoveInputReceived;
        characterControls.PlayerBehaviour.Move.performed -= OnMoveInputReceived;
        characterControls.Disable();
    }

}

