using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    /* 공격 : z
     * 방어 : ↓
     * 이동 : ←→
     * 점프 : x
     */

    // variable Define
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator animator;

    public float maxSpeed;
    public float jumpPower;

    // variable Reset
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Run();
        Jump();
        Fall();
        Block();
        Roll();
        SpriteController();
    }

    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        // Movement Function
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h * 2, ForceMode2D.Impulse);

        // Max Speed Function
        if (rigid.velocity.x != 0)
        {
            if (rigid.velocity.x > maxSpeed)
                rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
            else if (rigid.velocity.x < maxSpeed * (-1))
                rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);
        }

    }

    void Run()
    {
        if (Mathf.Abs(rigid.velocity.x) < 0.3)
            animator.SetInteger("AnimState", 0);
        else
            animator.SetInteger("AnimState", 1);
    }

    void Jump()
    {
        // Jump Function
        if (Input.GetButtonDown("Jump") && !animator.GetBool("isJumping"))
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            animator.SetTrigger("Jump");
            animator.SetBool("isJumping", true);
        }
    }

    void Fall()
    {
        // Fall Function
        if (rigid.velocity.y < 0)
        {
            Debug.DrawRay(rigid.position, Vector3.down, new Color(0, 1, 0));
            RaycastHit2D raycastHit = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("Platform"));
            if (raycastHit.collider == null)
            {
                animator.SetFloat("AirSpeedY", -1);
                animator.SetBool("Grounded", false);
            }
            else if (raycastHit.collider != null)
                if (raycastHit.distance < 0.3f)
                {
                    animator.SetFloat("AirSpeedY", 1);
                    animator.SetBool("Grounded", true);
                    animator.SetBool("isJumping", false);
                }
        }
    }

    void Block()
    {
        if (Input.GetButtonDown("Block"))
            animator.SetTrigger("Block");
        else if (Input.GetButton("Block"))
            animator.SetBool("IdleBlock", true);
        else if (Input.GetButtonUp("Block"))
            animator.SetBool("IdleBlock", false);
    }

    void Roll()
    {
        if (Input.GetButtonDown("Roll"))
            animator.SetTrigger("Roll");
    }

    void SpriteController()
    {
        // Stop Speed Function
        if (Input.GetButtonUp("Horizontal"))
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);

        // Direction Sprite Function
        if (Input.GetButton("Horizontal"))
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
    }
}

