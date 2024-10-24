using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{


    private Vector2 movement;
    private Rigidbody2D rb;
    [SerializeField] 
    private int speed = 5;
    private Animator animator;
    private Inventory inventory;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        inventory = new Inventory();
    }


    private void OnMovement(InputValue value)
    {
        movement = value.Get<Vector2>();

        if(movement.x != 0 || movement.y != 0)
        {
            animator.SetFloat("X", movement.x);
            animator.SetFloat("Y", movement.y);

            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }

    }

    private void FixedUpdate()
    {
        playerMovement();
        
    }

    private void playerMovement()
    {
        //The way we make the charactere move will depend on the type of game we want to create

        //Variant 1 -->  based on position
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);


        //Variant 2 --> physics based solution /// Also modify linear drag to stope the player from moveming
        /* if ((movement.x != 0 || movement.y != 0))
         {
             rb.velocity = movement * speed;
         }*/


        //Variant 3 
        //rb.AddForce(movement * speed);

    }

}
