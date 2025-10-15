using UnityEngine;
using UnityEngine.InputSystem;

public class TankControllerV2 : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;

    private Vector2 moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        Vector2 movement = new Vector2(moveInput.x * moveSpeed, rb.linearVelocity.y);
        rb.linearVelocity = movement;
    }
}
