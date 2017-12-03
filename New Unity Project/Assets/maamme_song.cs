using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maamme_song : MonoBehaviour {

    //public AudioClip maamme;

    public AudioSource audioSource;

    // Use this for initialization
    void Start ()
    {
        //audioSource.clip = maamme;	
        audioSource.volume = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        audioSource.volume = transform.position.y / 12;
        if (transform.position.y < -1.7)
        {
            audioSource.volume = 0;
        }
	}
}
