using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    private Animator upAnim;
    public int damage = 5;


    private void Start()
    {

        if (gameObject.name == "AttackPosUp")
        {
            upAnim = gameObject.GetComponent<Animator>();
        }
    }



    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger != true && collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().TakeDamage(damage);
        }
    }


    public void thunder(Vector3 mousePos, GameObject thunderprefab)
    {

        GameObject clone = Instantiate(thunderprefab, mousePos, Quaternion.identity);
        Destroy(clone, 1f);
    }
}
