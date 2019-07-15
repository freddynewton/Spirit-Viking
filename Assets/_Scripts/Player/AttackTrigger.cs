using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    private Animator upAnim;
    public Camera camera;

    /*
    private void Update()
    {
        while (transform.childCount > 0)
        {
            Destroy(transform.GetChild(0).gameObject);
        }
    }
    */

    private void Start()
    {
        if(gameObject.name == "AttackPosUp")
        {
            upAnim = GetComponent<Animator>();
        }
    }

    public int damage = 5;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger != true && collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().TakeDamage(damage);
        }
    }


    public void thunder()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        transform.position = mousePos;
        upAnim.SetTrigger("thunder");
    }
}
