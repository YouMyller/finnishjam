using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitSounds : MonoBehaviour {

    public AudioClip hitSound;
    public AudioClip critHitSound;

    public AudioSource audioSource;

    // Use this for initialization
    void Start ()
    {
        audioSource.clip = hitSound;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("KarhuTrigger") || collision.gameObject.CompareTag("VaimoTrigger"))
        {
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                audioSource.Play();
                //SoundManager.instance.RandomizeSfx(hitSound, critHitSound);
            }
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
