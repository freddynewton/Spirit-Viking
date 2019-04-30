using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float Speed;
    private Vector2 moveVelocity;
    private Rigidbody2D rb;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        move();

        if (rb.transform)
        {
           //transform.scale x-1 
        }
    }

    void move()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        anim.SetBool("isMoving", moveInput.magnitude != 0);

        anim.SetFloat("VelocityX", moveInput.x);
        anim.SetFloat("VelocityY", moveInput.y);
        moveVelocity = moveInput.normalized * Speed;
        rb.MovePosition(rb.position + moveVelocity * Time.deltaTime);
    }

}
