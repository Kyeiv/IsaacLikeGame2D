using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public AudioClip backgroundSound;
    public AudioSource audioSrc;
    public bool mute = true;
    // Start is called before the first frame update
    void Start()
    {
        audioSrc.clip = backgroundSound;
        //backgroundSound = Resources.Load<AudioClip>("music");
        //audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            mute = !mute;
        }
        if (!mute)
        {
            audioSrc.Play();
        }
        
    }

    /*public static void PlaySound()
    {
        audioSrc.PlayOneShot(backgroundSound);
    }*/
}
