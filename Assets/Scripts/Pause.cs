using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject menuHolder;
    void Start()
    {
        Time.timeScale = 1;
        menuHolder.active = false;
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
}