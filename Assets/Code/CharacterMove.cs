using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public Main MasterScript;

    Rigidbody2D rb;
    public float speed = 10f;
    public float jumpForce = 10f;
    float moveInput;

    bool isGrounded;
    public Collider2D feetCollider;
    public float checkRadius;
    public LayerMask whatIsGround;

    float jumpTimeCounter;
    public float jumpTime;
    bool isJumping;

    CharacterAnimation animationScript;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animationScript = GetComponentInChildren<CharacterAnimation>();
    }

    void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (moveInput < 0)
        {
            animationScript.FlipCharacterSprite(true);
        }
        else if (moveInput > 0)
        {
            animationScript.FlipCharacterSprite(false);
        }

        animationScript.SetCharacterWalk((moveInput == 0 ? false:true));
    }
    void Update()
    {
        JumpUpdate();

    }

    void JumpUpdate()
    {
        if (feetCollider.IsTouchingLayers(whatIsGround))
            isGrounded = true;
        else
            isGrounded = false;

        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            animationScript.AnimateJump();
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }

        if (rb.velocity.y == 0 || isGrounded)
        {
            animationScript.SetCharacterJump(false);
        }
        else
        {
            animationScript.SetCharacterJump(true);
        }


        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Meta")
            MasterScript.NextLevel();
        if (collision.tag == "Platform")
            transform.parent = collision.gameObject.transform;
        if (collision.tag == "Puas")
            MasterScript.GameOver();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Platform")
           transform.parent = null;
    }
}
