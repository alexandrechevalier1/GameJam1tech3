using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronManMovementManager : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    private bool isJumping;
    public bool isGrounded;

    public bool isplayerone;
    public Rigidbody2D rb;
    public Transform player;
    public SpriteRenderer spriteRenderer;
    public Animator animator;

    public Transform leftFoot;
    public Transform rightFoot;
    public LayerMask CollisionLayer;

    private Vector3 velocity = Vector3.zero;
    private float horizontalMovement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isplayerone)
        {
            if (Input.GetKey(KeyCode.Q) == true)
            {
                horizontalMovement = -1 * moveSpeed * Time.fixedDeltaTime;
            }
            if (Input.GetKey(KeyCode.D) == true)
            {
                horizontalMovement = 1 * moveSpeed * Time.fixedDeltaTime;
            }
            if (Input.GetKey(KeyCode.Q) == false && Input.GetKey(KeyCode.D) == false)
            {
                horizontalMovement = 0;
            }
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                isJumping = true;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftArrow) == true)
            {
                horizontalMovement = -1 * moveSpeed * Time.fixedDeltaTime;
            }
            if (Input.GetKey(KeyCode.RightArrow) == true)
            {
                horizontalMovement = 1 * moveSpeed * Time.fixedDeltaTime;
            }
            if (Input.GetKey(KeyCode.LeftArrow) == false && Input.GetKey(KeyCode.RightArrow) == false)
            {
                horizontalMovement = 0;
            }
            if (Input.GetKey(KeyCode.UpArrow) && isGrounded)
            {
                isJumping = true;
            }
        }

        Flip(rb.velocity.x);
        float characterVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed", characterVelocity);
        animator.SetBool("isGrounded", isGrounded);
        animator.SetFloat("VerticalSpeed", rb.velocity.y);
    }
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapArea(leftFoot.position, rightFoot.position, CollisionLayer);
        MovePlayer(horizontalMovement);
    }

    void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

        if (isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }
    }

    void Flip(float _velocity)
    {
        if (_velocity > 0.1f)
        {
            //player.localScale.Set(Mathf.Abs(player.localScale.x), player.localScale.y, player.localScale.z);
            //spriteRenderer.flipX = false;
            player.localScale = new Vector3(Mathf.Abs(player.localScale.x), player.localScale.y, player.localScale.z);
        }
        else if (_velocity < -0.1f)
        {
            // player.localScale.Set(-Mathf.Abs(player.localScale.x), player.localScale.y, player.localScale.z);
            player.localScale = new Vector3(-Mathf.Abs(player.localScale.x), player.localScale.y, player.localScale.z);
            // spriteRenderer.flipX = true;
        }
    }

    public void SetHorizontalMovement(float val)
    {
        horizontalMovement = val;
    }
}
