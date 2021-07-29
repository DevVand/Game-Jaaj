using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarpetDust : MonoBehaviour
{
    GameManager manager;
    Cleaner cleaner;
    public GameObject particles;
    public float dirtness = 5;
    public float sizingRate = .85f; 
    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>(); ;
        cleaner = GameObject.FindGameObjectWithTag("Player").transform.Find("Cleaner").GetComponent<Cleaner>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Input.GetButtonDown("Use"))
            {
                GameObject particle = Instantiate(particles);
                particle.transform.position = collision.transform.position;
                dirtness -= cleaner.cleanningKeyRate;
                transform.localScale *= sizingRate;
                if (dirtness <= 0) {
                    Destroy(this.gameObject);
                    manager.dirtCleaned();
                }
            }
        }
    }
}
