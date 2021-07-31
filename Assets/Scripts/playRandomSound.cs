using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playRandomSound : MonoBehaviour
{
    public AudioSource source;
    public AudioClip[] sounds;
    public float volume = 1;
    private void Start()
    {
        if(source==null)
            source = GetComponent<AudioSource>();    
    }
    public void playRandom() {
        
        source.PlayOneShot(sounds[Random.RandomRange(0, sounds.Length)], volume);
    }
}
