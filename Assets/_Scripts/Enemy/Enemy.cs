using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public int points;

    bool dead = false;

    private Animator anim;
    public ScoreManager scoreManager;

    //public GameObject bloodEffect;

    // private Animatior anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        health = maxHealth;
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
       

        if(health <= 0)
        {
            if (!dead)
            {
                scoreManager.score++;
                scoreManager.points += points;
                dead = true;
            }
            Destroy(gameObject, 2f);
        }
        
    }

    public void TakeDamage(int damage)
    {
        //Instantiate(bloodEffect, transform.position, Quaternion.identity);
        health -= damage;

        if(health > 0)
        {
            anim.SetTrigger("hurt");
        }
    }
}
