using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private CharacterControl characterControls;
    private Transform playerTransform;
    private Vector2 moveDirection;
    private Rigidbody2D rididbody;

    [SerializeField] private float velocity = 10;
    [SerializeField] private float jumpForce = 400;

    private void Awake()
    {
        rididbody = GetComponent<Rigidbody2D>();
        playerTransform = GetComponent<Transform>();
        characterControls = new CharacterControl();

        characterControls.PlayerBehaviour.Move.started += OnMoveInputReceived;
        characterControls.PlayerBehaviour.Move.canceled += OnMoveInputReceived;
        characterControls.PlayerBehaviour.Move.performed += OnMoveInputReceived;

        characterControls.PlayerBehaviour.Jump.started += OnJumpInputReceived;

    }


    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        playerTransform.Translate(new Vector2(moveDirection.x, moveDirection.y) * velocity * Time.deltaTime);
    }
    private void OnJumpInputReceived(InputAction.CallbackContext context)
    {
        bool isJumpPressed = context.ReadValueAsButton();

        if (isJumpPressed) 
        {
            rididbody.AddForce(Vector2.up * jumpForce); ;
        }
    }

    private void OnMoveInputReceived(InputAction.CallbackContext context)
    {
        moveDirection.x = context.ReadValue<float>();
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

