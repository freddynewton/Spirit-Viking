using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioSource[] audioTracksPlayer;
    public AudioSource[] audioTracksEnemies;
    public AudioSource[] audioTracksEnvironment;

    private static bool sfxmanExists;

    // Start is called before the first frame update
    void Start()
    {
        if (!sfxmanExists)
        {
            sfxmanExists = true;
            DontDestroyOnLoad(transform.gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }
}
