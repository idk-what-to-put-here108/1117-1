using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Initial Player Stats")]
    // initial player stats
    [SerializeField] private float initialSpeed = 1;
    [SerializeField] private int initalHealth = 100;

    //private fields
    private PlayerStats stats;
    private Vector2 moveInput;

    // Components
    private Rigidbody2D rbody;

    public int speed = 1;
    

    // Feild Variable
    
    void Awake()
    {
        // Initialize
        rbody = GetComponent<Rigidbody2D>();

        stats = new PlayerStats();
        stats.MoveSpeed = initialSpeed;
        stats.MaxHealth = initalHealth;
        stats.CurrentHealth = initalHealth;

    }
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void FixedUpdate()
    {
        
        ApplyMovement();
    }

    private void ApplyMovement()
    {
        float velocityX = moveInput.x * stats.MoveSpeed;
        rbody.linearVelocity = new Vector2(velocityX * speed, rbody.linearVelocity.y);

    }

    public void TakeDamage(int damageAmount)
    {
        stats.CurrentHealth -= damageAmount;
        //stats.CurrentHealth = stats.CurrentHealth - damageAmount
        Debug.Log("Took Damage");
    }
}
