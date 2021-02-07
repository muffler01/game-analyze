using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAI : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator animator;
    SpriteRenderer spriteRenderer;
    CapsuleCollider2D capsulecollider;

    public int nextMove;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        capsulecollider = GetComponent<CapsuleCollider2D>();

        Invoke("Think", 5);
    }

    void FixedUpdate()
    {
        // [Move Function]
        rigid.velocity = new Vector2(nextMove, rigid.velocity.y);

        // [PlatformCheck Function]
        Vector2 frontVec = new Vector2(rigid.position.x + nextMove * 0.4f, rigid.position.y);

        Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("Platform"));

        if (rayHit.collider == null)
        {
            Turn();
        }
    }

    void Think()
    {
        // [NextActive Function]
        nextMove = Random.Range(-1, 2);

        // [SpriteAnimation Function]
        animator.SetInteger("WalkSpeed", nextMove);
        
        // [FlipSprite Function]
        if (nextMove != 0)
            spriteRenderer.flipX = nextMove == 1;

        // [Recursive Function]
        float nextThinkTime = Random.Range(2f, 5f);
        Invoke("Think", nextThinkTime);
    }

    void Turn()
    {
        nextMove = nextMove * -1;
        spriteRenderer.flipX = nextMove == 1;

        CancelInvoke();
        Invoke("Think", 2);
    }

    // [OnDamaged Function]
    public void OnDamaged()
    {
        // Sprite Alpha
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);
        // Sprite Flip y
        spriteRenderer.flipY = true;
        // Collider Disable
        capsulecollider.enabled = false;
        // Die Effect Jump
        rigid.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
        // Destroy
        Invoke("DeActive", 5);
    }

    // [DeActive Function]
    void DeActive()
    {
        gameObject.SetActive(false);
    }
}
