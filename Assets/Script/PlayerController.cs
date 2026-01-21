using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : Character
{
    [Header("Movement Settings")]
    [SerializeField] private float jumpForce = 12f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.2f;



    // Components
    private Rigidbody2D rbody;
    private PlayerInputHandler input;
    private bool isGrounded;
    
    
    // Feild Variable
    
    protected override void Awake()
    {
        base.Awake();
        // Initialize
        rbody = GetComponent<Rigidbody2D>();
        input = GetComponent<PlayerInputHandler>();

    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }


    void FixedUpdate()
    {
        if (IsDead)
        {
            return;
        }
        HandleMovement();
        HandleJump();
    }

    private void HandleMovement()
    {
        float horizontalvelocity = input.MoveInput.x * MoveSpeed;

        rbody.linearVelocity = new Vector2(horizontalvelocity, rbody.linearVelocity.y);
    }

    private void HandleJump()
    {
        if(input.JumpTriggered && isGrounded)
        {
            ApplyJumpForce();
        }
    }

    private void ApplyJumpForce()
    {
        rbody.linearVelocity = new Vector2(rbody.linearVelocity.x, 0);

        rbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}
