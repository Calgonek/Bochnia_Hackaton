using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    private PlayerController pc;

    private float lastX = 0;
    private float lastY = -1;

    void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        pc = GetComponent<PlayerController>();
    }

    void Update()
    {
        Vector2 velocity = rb.linearVelocity;
        float speed = velocity.magnitude;

        if (speed > 0.1f)
        {
            lastX = velocity.x;
            lastY = velocity.y;
        }

        animator.SetFloat("Horizontal", velocity.x);
        animator.SetFloat("Vertical", velocity.y);
        animator.SetFloat("LastHorizontal", lastX);
        animator.SetFloat("LastVertical", lastY);
        animator.SetFloat("Speed", speed);
        animator.SetBool("isGrounded", pc.isGrounded);
    }
}