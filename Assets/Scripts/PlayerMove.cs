using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
  
    public float moveSpeed = 5f;
   
    public Rigidbody Rb;
    private PlayerInput playerInput;
    public InputAction moveAction;
    //public InputAction playerControls;
    private Vector2 moveInput;
    Vector2 upVector = new Vector2(0f, 1f);
    //Vector2 movete = Vector2.zero;
    private void Awake()
    {
        Rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions["Move"];

      

    }

    private void OnEnable()
    {
        moveAction.performed += OnMove;
        //playerControls.Enable();
    }

    private void OnDisable()
    {
        moveAction.performed -= OnMove;
       //playerControls.Disable();
    }

    // Update is called once per frame

    void OnMove(InputAction.CallbackContext context)
    {
        //upVector = context.ReadValue<  Vector2>();
        //moveInput = context.ReadValue< Vector2>();
    }

    void Update()
    {
        moveInput = moveAction.ReadValue<Vector2>();
        //movete = playerControls.ReadValue<Vector2>();
        HandleMovement();
       //transform.position = moveInput;
       // transform.position = upVector;
        // Vector2 move = transform.up * moveInput.y + transform.forward * moveInput.y;
    }


    void HandleMovement()
    {
       //transform.position = moveInput;
        Vector2 move = transform.up * moveInput.y + transform.forward * moveInput.x;
        Vector3 velocity = new Vector3(move.x * moveSpeed, Rb.velocity.y);
        Rb.velocity = velocity;
    }


    private void FixedUpdate()
    {
        //Rb.velocity = new Vector2 (move *  moveSpeed, move.x * moveSpeed);
    }

}
