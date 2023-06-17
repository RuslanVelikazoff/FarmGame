using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour
{
    [SerializeField]public float speed = 2f;

    public Vector2 motionVector;
    public Vector2 lastMotionVector;

    public bool moving;
    
    private Rigidbody2D rigidbody2D;
    private Animator animator;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        
        motionVector = new Vector2(horizontal, vertical);
        
        //Анимация
        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);

        moving = horizontal != 0 || vertical != 0;
        animator.SetBool("moving", moving);
        
        if (horizontal != 0 || vertical != 0)
        {
            lastMotionVector = new Vector2(horizontal, vertical).normalized;
            
            animator.SetFloat("lastHorizontal", horizontal);
            animator.SetFloat("lastVertical", vertical);
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rigidbody2D.velocity = motionVector * speed;
    }
}
