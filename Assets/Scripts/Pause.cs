using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public GameObject menuHolder;
    public bool original = false;

    public AudioMixer mixer;
    public Slider audioSslider;

    public float volume = 0;
    void Start()
    {
        Time.timeScale = 1;
        menuHolder.active = false;

        DontDestroyOnLoad(this);
        if (GameObject.FindGameObjectsWithTag("Pause").Length > 1)
        {
            if (!original)
            {
                DestroyImmediate(this.gameObject, true); ;
            }
        }
        original = true;

    }
    void Update()
    {
        if (Input.GetButtonDown("Pause")) {
            if (menuHolder.active){
                Time.timeScale = 1;
                menuHolder.active = false;
            } else {
                Time.timeScale = 0;
                menuHolder.active = true;
            }
        }
    }

    public void volumeChange() {
        mixer.SetFloat("volume", audioSslider.value);
    }
    public void back()
    {
        Time.timeScale = 1;
        menuHolder.active = false;
    }
    public void exit() {
        Application.Quit();
    }
}