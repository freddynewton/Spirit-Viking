using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Animator anim;
    public Transform attackPosCircle;
    public Transform attackPosSide;
    public Transform attackPosUp;
    public float attackRange;
    public LayerMask whatIsEnemies;
    public int damage;
    public float timeLeft = -1f;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
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
            timeLeft = 5f; 
            anim.SetTrigger("isSlayCircle");
            

           
        }
        if (timeLeft >= 0)
        {
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPosCircle.position, attackRange, whatIsEnemies);
            for (int i = 0; i < enemiesToDamage.Length; i++)
            {
                enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
            }
            timeLeft -= Time.deltaTime;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPosCircle.position, attackRange);
    }
}
