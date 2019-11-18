using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    private float speed = 6f;
    private Rigidbody2D body;
    Vector2 movement;
    private Animator animator;
 
    void Update()
    {
        body = gameObject.GetComponent<Rigidbody2D>();    

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator = gameObject.GetComponent<Animator>();
            
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        if (movement.x != 0 && movement.y != 0) 
        {
            movement.x *= 0.5f;
            movement.y *= 0.5f;
        }

        body.MovePosition(body.position + movement * speed * Time.deltaTime);
    }


}
