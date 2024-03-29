﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Dialogue : MonoBehaviour
{
    BackgroundMusic BGMusic;
    public bool destroyPlayer = false;
    public bool endMusic = false;
    public int actualDialogue = 0;
    public int totalDialogues = 2;
    public int scene = 0;
    public string nextScene = "room 1";
    Animator anim;
    [SerializeField] Animator animFade;
    void Start()
    {
        if (destroyPlayer)
            DestroyImmediate(GameObject.FindGameObjectWithTag("Player"),true);
        BGMusic = GameObject.FindGameObjectWithTag("BGMusic").GetComponent<BackgroundMusic>();
        anim = GetComponent<Animator>();
        //Invoke(nameof(playScene), .5f);
    }
    public void DialogueAdvance()
    {
        if (actualDialogue >= totalDialogues)
        {
            if (endMusic) {
                BGMusic.on = false;
            }
            animFade.SetBool("fade", false);
            Invoke(nameof(loadScene), 1.5f);
            return;
        }
        if(actualDialogue>0)
            anim.Play("fadeout" + actualDialogue, 1);
        actualDialogue += 1;

        anim.Play("panel" + actualDialogue, 0);
    }
    public void DialogueTXTUpdate() {
        anim.Play("fadein" + (actualDialogue), 1);
    }
    public void playScene()
    {
        //anim.Play("scene" + scene);
    }
    public void loadScene() {
        SceneManager.LoadScene(nextScene);
    }
    public void turnMusicOn() {
        BGMusic.on = true;
    }

}
