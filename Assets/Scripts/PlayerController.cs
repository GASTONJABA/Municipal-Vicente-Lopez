using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;
    public float jumpForce = 5f;

    [Header("Camera")]
    public float mouseSensitivity = 2f;
    public Camera playerCamera;

    [Header("Shooting")]
    public GameObject bulletPrefab;
    public Transform shootPoint;
    public float bulletSpeed = 20f;
    public float lifeBullet = 3;

    private Rigidbody rb;
    private PlayerInput playerInput;
    private InputAction moveAction;
    private InputAction lookAction;
    private InputAction jumpAction;
    private InputAction shootAction;

    private Vector2 moveInput;
    private Vector2 lookInput;
    private bool isGrounded;
    private float verticalLookRotation = 0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        
        moveAction = playerInput.actions["Move"];
        lookAction = playerInput.actions["Look"];
        jumpAction = playerInput.actions["Jump"];
        shootAction = playerInput.actions["Shoot"];
    }

    private void OnEnable()
    {
        moveAction.performed += OnMove;
        moveAction.canceled += OnMove;
        lookAction.performed += OnLook;
        lookAction.canceled += OnLook;
        jumpAction.performed += OnJump;
        shootAction.performed += OnShoot;
    }

    private void OnDisable()
    {
        moveAction.performed -= OnMove;
        moveAction.canceled -= OnMove;
        lookAction.performed -= OnLook;
        lookAction.canceled -= OnLook;
        jumpAction.performed -= OnJump;
        shootAction.performed -= OnShoot;
    }

    private void Update()
    {
        HandleMovement();
        HandleMouseLook();
    }

    // ---- MOVIMIENTO ----
    void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    void HandleMovement()
    {
        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;
        Vector3 velocity = new Vector3(move.x * moveSpeed, rb.velocity.y, move.z * moveSpeed);
        rb.velocity = velocity;
    }

    // ---- MOVIMIENTO CAMARA ----
    void OnLook(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
    }

    void HandleMouseLook()
    {
        float mouseX = lookInput.x * mouseSensitivity;
        float mouseY = lookInput.y * mouseSensitivity;

        transform.Rotate(Vector3.up * mouseX);

        verticalLookRotation -= mouseY;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);
        playerCamera.transform.localEulerAngles = new Vector3(verticalLookRotation, 0, 0);
    }

    // ---- SALTO ----
    void OnJump(InputAction.CallbackContext context)
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            Debug.Log("Jump!");
        }
    }

    // ---- DISPARO ----
    void OnShoot(InputAction.CallbackContext context)
    {
        GameObject bulletObj = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody bulletRb = bulletObj.GetComponent<Rigidbody>();
        bulletRb.AddForce(shootPoint.forward * bulletSpeed, ForceMode.Impulse);
        Destroy(bulletObj, lifeBullet);
        Debug.Log("Shoot!");
    }

    // ---- DETECCIÓN DE SUELO ----
    void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }

    void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}