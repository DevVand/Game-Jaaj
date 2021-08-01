using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class playerSound : MonoBehaviour
{
    Rigidbody2D rdbd;
    AudioSource source;
    public AudioMixer effect;
    public AudioMixerSnapshot snapshotsOn;
    public AudioMixerSnapshot snapshotsOff;
    void Start()
    {
        source = GetComponent<AudioSource>();

        rdbd = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        source.pitch = .6f + ((rdbd.velocity.magnitude / 3.24f) / 2);
        //effect.SetFloat("pitch",.4f+((rdbd.velocity.magnitude/3.34f)/2));
        //effect.SetFloat("pitch", 2);
    }
    public void soundOn() { snapshotsOn.TransitionTo(1); }
    public void soundOff() { snapshotsOff.TransitionTo(2); }
}
