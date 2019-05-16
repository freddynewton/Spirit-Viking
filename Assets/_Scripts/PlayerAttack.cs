using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Animator anim;
    public Transform attackPos;
    public float attackRange;
    public LayerMask whatIsEnemies;
    public int damage; 

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if(timeBtwAttack <= 0)
        { 
            if (Input.GetMouseButtonDown(0))
            {

                anim.SetTrigger("isSlaySide");

            }
            else if (Input.GetMouseButtonDown(1))
            {
                anim.SetTrigger("isSlayUp");
            }
            else if (Input.GetKeyDown("e"))
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                }

                anim.SetTrigger("isSlayCircle");
            }

            timeBtwAttack = startTimeBtwAttack;
        } else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
