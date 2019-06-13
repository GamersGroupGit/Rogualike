using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    public Animator animator;

    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private int direction;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
    }

    private void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;

        animator.SetFloat("Speed", Mathf.Abs(moveVelocity.x));

        if (moveVelocity.x < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetBool("Strike", true);
        } else if (Input.GetKeyUp(KeyCode.F))
        {
            animator.SetBool("Strike", false);
        }

        if (direction == 0)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                direction = 1;
            }
            else if (Input.GetKeyDown(KeyCode.L))
            {
                direction = 2;
            }
            else if (Input.GetKeyDown(KeyCode.I))
            {
                direction = 3;
            }
            else if (Input.GetKeyDown(KeyCode.K))
            {
                direction = 4;
            }
        }
        else
        {
            if (dashTime <= 0)
            {
                direction = 0;
                dashTime = startDashTime;
                rb.velocity = Vector2.zero;
            }
            else
            {
                dashTime -= Time.deltaTime;
                if (direction == 1)
                {
                    rb.AddForce(Vector2.left * dashSpeed);
                }
                else if (direction == 2)
                {
                    rb.AddForce(Vector2.right * dashSpeed);
                }
                else if (direction == 3)
                {
                    rb.AddForce(Vector2.up * dashSpeed);
                }
                else if (direction == 4)
                {
                    rb.AddForce(Vector2.down * dashSpeed);
                }
            }
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }
}
