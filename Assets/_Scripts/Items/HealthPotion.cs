using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    public int healAmount;
    public int points;
    public ScoreManager scoreManager;

    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerAttack>().TakeHeal(healAmount);
            scoreManager.points += points;
            DestroyObject();
        }
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }


}
