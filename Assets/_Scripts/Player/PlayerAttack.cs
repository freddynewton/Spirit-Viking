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
    public float curMana;
    [HideInInspector]
    public Slider HealthSlider;
    [HideInInspector]
    public Slider ManaSlider;


    private float timeBtwAttack;
    private int killedEnemiesCounter;
    private ParticleSystem fireCicle;
    private bool attacking = false;
    private int damage;

    public float startTimeBtwAttack;
    public Animator anim;
    public Collider2D attackPosCircle;
    public Collider2D attackPosSide;
    public GameObject attackPosUpObject;

    public int maxHealth;
    public float maxMana;

    ParticleSystem fireCircle;

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
        fireCicle = GameObject.Find("FireCircleParticle").GetComponent<ParticleSystem>();
        fireCicle.Stop();

        attackPosCircle.enabled = false;
        attackPosSide.enabled = false;

        if (HealthSlider == null)
        {
            HealthSlider = GameObject.Find("HealthSlider").GetComponent<Slider>();
        }
        if (ManaSlider == null)
        {
            ManaSlider = GameObject.Find("ManaSlider").GetComponent<Slider>();
        }

        this.transform.position = Vector3.zero;
        curHealth = maxHealth;
        curMana = maxMana;
        HealthSlider.value = maxHealth; 
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.GameIsPaused)
        {
            AddMana(0.075f);
            attack();
            
            if(curHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
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

                
            }
        }

        if (Input.GetMouseButtonDown(0) && !attacking)
        {
            attacking = true;
            timeBtwAttack = 0.3f;
            attackPosSide.enabled = true;
            anim.SetTrigger("isSlaySide");

        }
        else if (Input.GetMouseButtonDown(1) && !attacking && curMana >= 35)
        {
            attacking = true;
            timeBtwAttack = 2f;
            anim.SetTrigger("isSlayUp");
            TakeMana(35f);
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 1;
            attackPosUpObject.GetComponent<AttackTrigger>().thunder(mousePos, attackPosUpObject);
            

        }
        else if (Input.GetKeyDown("e") && !attacking && curMana >= 100)
        {
            attacking = true;
            timeBtwAttack = 5f;
            attackPosCircle.enabled = true;
            anim.SetTrigger("isSlayCircle");
            TakeMana(100f); 
            fireCicle.Play();

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

    public void TakeMana(float mana)
    {
        curMana -= mana;
        ManaSlider.value = curMana;
    }

    public void AddMana(float mana)
    {
        if (curMana <= maxMana)
        {
            curMana += mana;
            ManaSlider.value = curMana;
        }
    }
    

}
