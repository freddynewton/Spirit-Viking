using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float Speed;
    private Vector2 moveVelocity;
    private Rigidbody2D rb;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
        anim.SetFloat("VelocityX", movement.x);
        anim.SetFloat("VelocityY", movement.y);
        anim.SetFloat("Magnitude", movement.magnitude);

        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("isSlaySide");
        } else if (Input.GetMouseButtonDown(1))
        {
            anim.SetTrigger("isSlayUp");
        } else if (Input.GetKeyDown("e"))
        {
            anim.SetBool("isSlayCircle", true);
            anim.SetBool("isSlayCircle", false);
        }

        transform.position = transform.position + movement * Time.deltaTime;
    }

}
