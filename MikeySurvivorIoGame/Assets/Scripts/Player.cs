using UnityEngine;

public class Player : MonoBehaviour
{
    float horizontal;
    [SerializeField] float speed = 8f;
    [SerializeField] float jumpingPower = 16f;
    bool isFacingRight;

    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;

    [SerializeField] float voidDistance = -25f;

    [SerializeField] GameObject live1;
    [SerializeField] GameObject live2;
    [SerializeField] GameObject live3;
    int liveCount = 3;

    void Update()
    {
        if (transform.position.y <= voidDistance)
        {
            Debug.Log("Fell out of world.");
            transform.position = Vector3.zero;
            if (liveCount == 3) Destroy(live1);
            else if (liveCount == 2) Destroy(live2);
            else if (liveCount == 1) 
            { 
                Destroy(live3); Debug.Log("You lost all your lives.");
            }
            liveCount--;
        }
        
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.x > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        Flip();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2 (horizontal * speed, rb.velocity.y);
    }

    bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
