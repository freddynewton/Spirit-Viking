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


        
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);


        if (mousePos.x < this.transform.position.x)
        {
            this.transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else
        {
            this.transform.localScale = new Vector3(1f, 1f, 1f);
        }
        transform.position = transform.position + movement * Time.deltaTime;
    }

}
