using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Components
    private Rigidbody2D rbody;

    public int speed = 10;
    

    // Feild Variable
    private Vector2 moveInput;
    void Awake()
    {
        // Initialize
        rbody = GetComponent<Rigidbody2D>();
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
        float velocityX = moveInput.x;
        rbody.linearVelocity = new Vector2(velocityX * speed, rbody.linearVelocity.y);

    }
}
