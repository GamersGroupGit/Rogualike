using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;

        animator.SetFloat("Speed", Mathf.Abs(moveVelocity.x));//Abs() - метод, который позволяет взять модуль числа

        if (moveVelocity.x < 0)
        {//поворот спрайта персонажа в зависимости от направления движения
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {//анимация удара при удержании клавиши F
            animator.SetBool("Strike", true);
        }
        else if (Input.GetKeyUp(KeyCode.F))
        {
            animator.SetBool("Strike", false);
        }
    }

    private void FixedUpdate()
    {//FixedUpdate() метод, который позволяем управлять физикой объекта
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }

}
