using UnityEngine;
using UnityEngine.InputSystem;

public class TankController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;

    // A private variable to store the player's movement input
    private Vector2 moveInput;

    void Start()
    {
        // Get a reference to the Rigidbody2D on this GameObject
        rb = GetComponent<Rigidbody2D>();
    }

    // This method is automatically called when the "Move" action is triggered.
    // It takes an InputValue object that contains the input data.
    public void OnMove(InputValue value)
    {
        // Read the 2D vector value from the input action
        moveInput = value.Get<Vector2>();
    }

    // FixedUpdate is used for physics calculations
    void FixedUpdate()
    {
        // Calculate the movement vector based on the input and move speed
        Vector2 movement = new Vector2(moveInput.x * moveSpeed, rb.linearVelocity.y);

        // Apply the velocity to the Rigidbody2D
        rb.linearVelocity = movement;
    }
}
