using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip impulse;
   // public AudioClip background;
    public AudioClip hit;

    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
       audioSource = audioSource.GetComponent<AudioSource>();
       audioSource.PlayOneShot(impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayHitSound()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(hit);
    }

    public void PlayImpulseSound()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(impulse);
    }
    
    
}
