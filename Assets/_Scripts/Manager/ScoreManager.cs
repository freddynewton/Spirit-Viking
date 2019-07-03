﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager Instance { get; private set; }
    public int score;


    public Text text;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
       
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (text == null)
        {
            text = GameObject.Find("ScoreText").GetComponent<Text>();
        }
        text.text = "Kills: " + score;
    }
}
