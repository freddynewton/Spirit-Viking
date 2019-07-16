using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathMenu : MonoBehaviour
{
    public static bool PlayerIsDead = false;

    public Text text;
    public Text pointText;

    int score;
    int points;

    public GameObject deathMenuUI;
    public GameObject hudMenuUI;



    // Update is called once per frame
    void Update()
    {
        if (hudMenuUI == null)
        {
            hudMenuUI = GameObject.Find("HUD");
        }
    
        if (!PlayerIsDead)
        {
            score = hudMenuUI.GetComponentInParent<ScoreManager>().score;
            points = hudMenuUI.GetComponentInParent<ScoreManager>().points;
        }


        if (text == null)
        {
            text = GameObject.Find("ScoreText").GetComponent<Text>();
        }
        text.text = "Kills: " + score;

        if (pointText == null)
        {
            pointText = GameObject.Find("PointText").GetComponent<Text>();
        }
        pointText.text = "Points: " + points;

        if (PlayerIsDead)
        {
            dead();
        }
    }

    public void dead()
    {
        deathMenuUI.SetActive(true);
        Destroy(GameObject.Find("SaveLoad"));
        Destroy(GameObject.Find("HUDCanvas"));
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        Time.timeScale = 0f;
        PlayerIsDead = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu"); 
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game - just for debug in Editor");
        Application.Quit();
    }
}
