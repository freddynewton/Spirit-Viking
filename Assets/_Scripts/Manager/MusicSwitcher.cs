using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSwitcher : MonoBehaviour
{
    private MusicManager theMC;
    public int newTrack;
    public bool switchOnStart;

    // Start is called before the first frame update
    void Start()
    {
        theMC = FindObjectOfType<MusicManager>();

        if (switchOnStart)
        {
            theMC.SwitchTrack(newTrack);
        }
    }

}
