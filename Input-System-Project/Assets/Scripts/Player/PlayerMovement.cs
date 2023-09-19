using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;

    private CharacterControl characterControls;

    private Rigidbody2D rididbody;

    private Transform playerTransform;

    private Vector2 moveDirection;

    private SpriteRenderer spriteRenderer;

    public Animator animator { get; set; }

    private int numberOfJumps = 0;
    public bool isRunning { get; set; }

    public bool isJumping = true;

    public bool isFalling { get; set; }

    public int cherrysCollectables = 3;

    private bool playerAlive = true;


    [SerializeField] private float velocity = 10;
    [SerializeField] private float jumpForce = 300;
    [SerializeField] private int maxNumberOfJumps = 2;
    [SerializeField] public int numberOfCherrysToWin;

    private void Awake()
    {
        #region Singleton
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        #endregion

        spriteRenderer = GetComponent<SpriteRenderer>();

        animator = GetComponent<Animator>();

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
            isJumping = true;
        }
    }

    private void OnMoveInputReceived(InputAction.CallbackContext context)
    {
        moveDirection.x = context.ReadValue<float>();
        isRunning = moveDirection.x == 1 || moveDirection.x == -1;
        FlipSprite(moveDirection.x);
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
        isJumping = false;

        if (collision.collider.CompareTag("Enemy"))
        {
            playerAlive = false;
            playerAlive = UIManager.instance.CheckPlayerAlive(playerAlive);
            Destroy(gameObject);
        }
    }

    public bool CheckPlayerRunning()
    {
        return isRunning;
    }

    public bool CheckPlayerJumping()
    {
        return isJumping;
    }

    private void FlipSprite(float moveDirection)
    {
        if (moveDirection == 1)
        {
            spriteRenderer.flipX = false;
        }
        else if (moveDirection == -1) 
        {
            spriteRenderer.flipX = true;
        }

    }

    public int CheckNumberOfCherrysToWin(int CherrysToWin)
    {
        CherrysToWin = numberOfCherrysToWin;
        return numberOfCherrysToWin;
    }

    public int CheckCherrysCollectables(int collectablesCherrys)
    {
        collectablesCherrys = cherrysCollectables;
        return cherrysCollectables;
    }

}

