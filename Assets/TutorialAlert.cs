using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialAlert : MonoBehaviour
{
    Animator anim;
    public bool disableOnExit = true;
    public bool destroyOnExit = true;

    public string tutorial = "";
    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Tutorial").GetComponent<Animator>();   
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            anim.Play(tutorial,1);
            anim.SetBool("open", true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (disableOnExit)
                anim.SetBool("open", false);
            if (destroyOnExit)
                Destroy(this.gameObject);
        }
    }
    private void OnDestroy()
    {
        anim.SetBool("open", false);
    }
}
