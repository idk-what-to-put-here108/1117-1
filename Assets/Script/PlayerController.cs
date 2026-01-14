using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Initial Player Stats")]
    // initial player stats
    [SerializeField] private float initialSpeed = 5;


    //private fields
    private PlayerStats stats;
    

    // Components
    private Rigidbody2D rbody;

    public int speed = 1;
    

    // Feild Variable
    private Vector2 moveInput;
    void Awake()
    {
        // Initialize
        rbody = GetComponent<Rigidbody2D>();

        stats = new PlayerStats();
        stats.MoveSpeed = initialSpeed;

    }
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void FixedUpdate()
    {
        
        ApplyMovement();
    }

    void ApplyMovement()
    {
        float velocityX = moveInput.x * stats.MoveSpeed;
        rbody.linearVelocity = new Vector2(velocityX * speed, rbody.linearVelocity.y);

    }
}
