using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private bool firstPlay = true;
    public AudioSource a;
    public AudioSource b;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!a.isPlaying && firstPlay) {
            b.Play();
            firstPlay = false;
        }
    }
}
