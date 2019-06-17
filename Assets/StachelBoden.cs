using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StachelBodenDamage : MonoBehaviour
{
    public int damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerAttack>().TakeDamage(damage);
        }
    }
}
