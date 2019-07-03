using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int maxHealth;

    public ScoreManager scoreManager;

    //public GameObject bloodEffect;

    // private Animatior anim;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            
            scoreManager.score++;
            Destroy(gameObject);
        }
        
    }

    public void TakeDamage(int damage)
    {
        //Instantiate(bloodEffect, transform.position, Quaternion.identity);
        health -= damage;

    }
}
