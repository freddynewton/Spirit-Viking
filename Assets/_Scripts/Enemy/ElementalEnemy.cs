using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementalEnemy : MonoBehaviour {
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public float startTargeting;

    private float timeBtwShots;
    public float startTimeBtwShots;
    public int damage;

    private Transform player;
    private int floorMask;
    private Animator anim;
    private bool playerInSight;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
        Physics2D.queriesStartInColliders = false;
        floorMask = LayerMask.GetMask("Wall");
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<Enemy>().health > 0)
        {
            life();
        }
        else
        {
            anim.SetTrigger("death");
        }
    }

    void life()
    {
        Vector3 dir = -(this.transform.position - player.transform.position).normalized;

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, dir, startTargeting, floorMask);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.gameObject.CompareTag("Player"))
            {
                Debug.DrawLine(transform.position, hitInfo.point, Color.green);
                playerInSight = true;
            }
            else
            {
                Debug.DrawLine(transform.position, hitInfo.point, Color.red);
                playerInSight = false;
            }
        }



        if (Vector2.Distance(transform.position, player.position) < startTargeting && playerInSight)
        {

            if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
                lookAtPlayer(true);
                anim.SetBool("isWalking", true);
            }

            else if (Vector2.Distance(transform.position, player.position) < stoppingDistance)
            {
                lookAtPlayer(true);
                transform.position = this.transform.position;
                anim.SetBool("isWalking", false);
            }


            if (timeBtwShots <= 0)
            {
                //Attack here
                timeBtwShots = startTimeBtwShots;
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && gameObject.GetComponent<Enemy>().health > 0)
        {
            collision.GetComponent<PlayerAttack>().TakeDamage(damage);
          

        }
    }


    public void lookAtPlayer(bool negiert)
    {
        if (negiert == false)
        {
            if (player.transform.position.x < this.transform.position.x)
            {
                this.transform.localScale = new Vector3(1f, 1f, 1f);
            }
            else
            {
                this.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }
        else
        {
            if (player.transform.position.x < this.transform.position.x)
            {
                this.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
            else
            {
                this.transform.localScale = new Vector3(1f, 1f, 1f);
            }
        }
    }

}

