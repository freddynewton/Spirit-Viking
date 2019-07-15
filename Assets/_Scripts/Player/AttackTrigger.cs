using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    private Animator upAnim;

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


    public void thunder(Vector3 mousePos, GameObject thunderprefab)
    {
        
        GameObject clone = Instantiate(thunderprefab, mousePos, Quaternion.identity);
        upAnim.SetTrigger("thunder");
        Destroy(clone, 1f);
    }
}
