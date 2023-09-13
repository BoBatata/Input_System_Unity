using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private CharacterControl characterControls;

    private Rigidbody2D rididbody;

    private Transform playerTransform;

    private Vector2 moveDirection;

    private int numberOfJumps = 0;

    [HideInInspector] public int cherrysCollectables = 0;

    [SerializeField] private float velocity = 10;
    [SerializeField] private float jumpForce = 400;
    [SerializeField] private int maxNumberOfJumps = 2;
    [SerializeField] private int numberOfCherrysToWin;

    private void Awake()
    {
        rididbody = GetComponent<Rigidbody2D>();

        characterControls = new CharacterControl();

        playerTransform = GetComponent<Transform>();

        characterControls.PlayerBehaviour.Move.started += OnMoveInputReceived;
        characterControls.PlayerBehaviour.Move.canceled += OnMoveInputReceived;
        characterControls.PlayerBehaviour.Move.performed += OnMoveInputReceived;

        characterControls.PlayerBehaviour.Jump.started += OnJumpInputReceived;

    }


    private void Update()
    {
        MovePlayer();
        CheckVictory();
        print(numberOfJumps);
    }


    private void MovePlayer()
    {
        playerTransform.Translate(new Vector2(moveDirection.x, moveDirection.y) * velocity * Time.deltaTime);
    }
    private void OnJumpInputReceived(InputAction.CallbackContext context)
    {
        bool isJumpPressed = context.ReadValueAsButton();

        if (isJumpPressed && numberOfJumps < maxNumberOfJumps) 
        {
            rididbody.AddForce(Vector2.up * jumpForce);
            numberOfJumps++;
        }
    }

    private void OnMoveInputReceived(InputAction.CallbackContext context)
    {
        moveDirection.x = context.ReadValue<float>();
    }

    private void CheckVictory()
    {
        if (cherrysCollectables >= numberOfCherrysToWin)
        {
            print("Win");
        }
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        numberOfJumps = 0;
    }

}

