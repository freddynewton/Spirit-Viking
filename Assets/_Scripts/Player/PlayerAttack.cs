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
    [HideInInspector]
    public Slider HealthSlider;

    private float timeBtwAttack;
    private int killedEnemiesCounter;
    private ParticleSystem fireCicle;
    private bool attacking = false;
    private int damage;

    public float startTimeBtwAttack;
    public Animator anim;
    public Collider2D attackPosCircle;
    public Collider2D attackPosSide;
    public Collider2D attackPosUp;
    //public float attackRange;
    //public LayerMask whatIsEnemies;

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
        attackPosCircle.enabled = false;
        attackPosSide.enabled = false;
        attackPosUp.enabled = false;

        if (HealthSlider == null)
        {
            HealthSlider = GameObject.Find("HealthSlider").GetComponent<Slider>();
        }
        this.transform.position = Vector3.zero;
        curHealth = maxHealth;
        HealthSlider.value = maxHealth; 
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    { 
        attack();
    }

    public void attack()
    {
        if (attacking)
        {
            if (timeBtwAttack > 0)
            { 
                timeBtwAttack -= Time.deltaTime;
            } else
            {
                attacking = false;
                attackPosCircle.enabled = false;
                attackPosSide.enabled = false;
                attackPosUp.enabled = false;
                
            }
        }

        if (Input.GetMouseButtonDown(0) && !attacking)
        {
            attacking = true;
            timeBtwAttack = 0.3f;
            attackPosSide.enabled = true;
            anim.SetTrigger("isSlaySide");

        }
        else if (Input.GetMouseButtonDown(1) && !attacking)
        {
            attacking = true;
            timeBtwAttack = 0.3f;
            attackPosUp.enabled = true;
            anim.SetTrigger("isSlayUp");
            Vector3 mousPos = Input.mousePosition;

        }
        else if (Input.GetKeyDown("e") && !attacking)
        {
            attacking = true;
            timeBtwAttack = 5f;
            attackPosCircle.enabled = true;
            anim.SetTrigger("isSlayCircle");

        }
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("Player TakeDamage: " + damage);
        curHealth -= damage;
        HealthSlider.value = curHealth;

    }

    public void TakeHeal(int heal)
    {
        Debug.Log("Player TakeHeal: " + heal);
        curHealth += heal;
        if (curHealth > maxHealth)
        {
            curHealth = maxHealth; 
        }

        HealthSlider.value = curHealth;
    }

}
