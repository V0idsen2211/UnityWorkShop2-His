using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public Transform feet;
    public float checkRadius;
    public LayerMask whatIsGround;
    public float jumpBuffer, coyoteTime;
    public Vector2 worldBorders;
    public GameObject jumpSound;
    
    private InputSystem_Actions inputActions;
    private float horizontalMoveInput;
    private Rigidbody2D rb;
    private Animator anim;
    
    private bool facingRight = true;

    private bool isGrounded;

    private float jumpBufferTimer, coyoteTimer;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputActions = new InputSystem_Actions();
        inputActions.Player.Enable();
        rb = GetComponent<Rigidbody2D>();
        anim =  GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feet.position, checkRadius, whatIsGround);
        horizontalMoveInput = inputActions.Player.Move.ReadValue<Vector2>().x;
        rb.linearVelocityX = horizontalMoveInput * moveSpeed;

        if (facingRight && horizontalMoveInput < 0)Turn();
        if (!facingRight && horizontalMoveInput > 0)Turn();


        if (isGrounded)
        {
            coyoteTimer = coyoteTime;
        }
        else
        {
            coyoteTimer -= Time.deltaTime;
        }

        if (inputActions.Player.Jump.triggered)
        {
            jumpBufferTimer = jumpBuffer;
        }
        else
        {
            jumpBufferTimer -= Time.deltaTime;
        }

        if (jumpBufferTimer > 0 && coyoteTimer > 0)
        {
            Jump();
        }
        HandleAnimations();
        transform.position = new Vector3(
            Mathf.Clamp(rb.position.x, -worldBorders.x, worldBorders.x),
            Mathf.Clamp(rb.position.y, -worldBorders.y, worldBorders.y),
            0);
    }

    private void Turn()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void Jump()
    {
        coyoteTimer = 0;
        jumpBufferTimer = 0;
        Instantiate(jumpSound, transform.position, transform.rotation);
        rb.linearVelocityY = jumpForce;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(feet.position, checkRadius);
    }

    private void HandleAnimations()
    {
        if (isGrounded)
        {
            if (horizontalMoveInput != 0)
            {
                anim.CrossFade("run", 0);
            }
            else
            {
                anim.CrossFade("idle", 0);
            }
        }
        else
        {
            anim.CrossFade("air", 0);
        }
        
    }
}
