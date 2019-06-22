using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public float startTargeting;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject projectile; 

    private Transform player;
    private int floorMask;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
        Physics2D.queriesStartInColliders = false;
        floorMask = LayerMask.GetMask("Floor");

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = -(this.transform.position - player.transform.position).normalized;

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, dir, startTargeting, floorMask);
        if(hitInfo.collider != null && hitInfo.collider.CompareTag("Player"))
        {
            Debug.DrawLine(transform.position, hitInfo.point, Color.green);
            if (hitInfo.collider.CompareTag("Player"))
            {
                print("hit player");
            }
        } else
        {
            Debug.DrawLine(transform.position, hitInfo.point, Color.red);
        }



        if (Vector2.Distance(transform.position, player.position) < startTargeting) {

            if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            } else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance) {
                transform.position = this.transform.position;
            } else if (Vector2.Distance(transform.position, player.position) < retreatDistance) {
                transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
            }


            if (timeBtwShots <= 0)
            {
                Instantiate(projectile, transform.position, Quaternion.identity);
                timeBtwShots = startTimeBtwShots;
            } else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }
    }
}
