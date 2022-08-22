using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource audioSource;
    
    public static AudioController Instance;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Playaudiosources(string namefile)
    {
        audioSource.clip = (AudioClip)Resources.Load("Sounds/" + namefile);
        audioSource.Play();
    }
}
