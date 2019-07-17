using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static bool mcExists;
    public bool musicCanPlay;
    public AudioSource[] musicTracks;
    public int currentTrack;


    // Start is called before the first frame update
    void Start()
    {
        if (!mcExists)
        {
            mcExists = true;
            DontDestroyOnLoad(transform.gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (musicCanPlay)
        {
            if (!musicTracks[currentTrack].isPlaying)
            {
                musicTracks[currentTrack].Play();
            }
        } else
        {
            musicTracks[currentTrack].Stop();
        }
    }

    public void SwitchTrack(int newTrack)
    {
        musicTracks[currentTrack].Stop();
        currentTrack = newTrack;
        musicTracks[currentTrack].Play();
    }
}
