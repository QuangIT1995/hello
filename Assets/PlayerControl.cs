using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float jumpForce = 10f;

    public float moveSpeed = 5f;

    private bool isGrounded;

    private bool canDoubleJump;

    private Rigidbody2D rb;

    private Animator animator;

    private float originalMoveSpeed;

    private bool isSpeedBoostActive;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  
        animator = GetComponent<Animator>();
        originalMoveSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 moveDirection = new Vector3(horizontalInput,0,0) * moveSpeed * Time.deltaTime;

        animator.SetBool("isMoving",true);

        if (Input.GetButtonDown("Jump")) 
        {
            if (isGrounded) 
            {
                Jump();
                canDoubleJump = true;
            }
            else if (canDoubleJump) 
            {
                Jump();
                canDoubleJump = false;
            }
        }
        transform.Translate(moveDirection);
    }

    void Jump() 
    {
        rb.velocity = new Vector2(rb.velocity.x,jumpForce);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) 
        {
            isGrounded = true;
            canDoubleJump = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) 
        {
            isGrounded = false;
        }
    }

    public void ActiveSpeedBoost(float boostAmount, float duration) 
    {
        if (!isSpeedBoostActive) 
        {
            StartCoroutine(SpeedBoost(boostAmount, duration));
        }
    }

    private IEnumerator SpeedBoost(float boostAmount, float duration) 
    {
        isSpeedBoostActive = true;
        moveSpeed += boostAmount;
        
        yield return new WaitForSeconds(duration);

        moveSpeed = originalMoveSpeed;
        isSpeedBoostActive = false;
    }
}
