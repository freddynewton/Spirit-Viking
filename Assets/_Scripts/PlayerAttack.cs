using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerAttack : MonoBehaviour
{
    [HideInInspector]
    public int curHealth;
    public Slider HealthSlider;

    private float timeBtwAttack;
    private int killedEnemiesCounter;
    private ParticleSystem fireCicle;

    public float startTimeBtwAttack;
    public Animator anim;
    public Transform attackPosCircle;
    public Transform attackPosSide;
    public Transform attackPosUp;
    public float attackRange;
    public LayerMask whatIsEnemies;
    public int damage;
    public float timeLeft = -1f;
    public int maxHealth;

    public static PlayerAttack Instance { get; private set; }



    private void Awake()
    {
        
        this.transform.position = Vector3.zero;
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        transform.position = Vector3.zero;
    }



    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = Vector3.zero;
        curHealth = maxHealth;
        HealthSlider.value = maxHealth; 
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (HealthSlider == null)
        {
            HealthSlider = GameObject.Find("HealthSlider").GetComponent<Slider>();
        }

        if (Input.GetMouseButtonDown(0))
        {

            anim.SetTrigger("isSlaySide");

        }
        else if (Input.GetMouseButtonDown(1))
        {
            Vector3 mousPos = Input.mousePosition;
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPosUp.position, attackRange, whatIsEnemies);

            anim.SetTrigger("isSlayUp");

        }
        else if (Input.GetKeyDown("e"))
        {

            damage = 5;
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

    public void TakeDamage(int damage)
    {
        Debug.Log("Player TakeDamage: " + damage);
        curHealth -= damage;
        HealthSlider.value = curHealth;

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPosCircle.position, attackRange);
        Gizmos.DrawWireSphere(attackPosUp.position, attackRange);
    }
}
