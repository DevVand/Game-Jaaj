using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalMessageSound : MonoBehaviour
{
    playRandomSound rndSound;
    void Start()
    {
        rndSound = GetComponent<playRandomSound>();
    }
    public void applause()
    {
        if (SceneManager.GetActiveScene().name != "room 3")
            rndSound.play(1);
    }
    public void winSound() {
            rndSound.play(0);
    }
}