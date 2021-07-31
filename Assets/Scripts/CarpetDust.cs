using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarpetDust : MonoBehaviour
{
    Transform player;
    GameManager manager;
    Cleaner cleaner;
    public GameObject particles;
    public float dirtness = 5;
    public float sizingRate = .85f;
    public bool canInteract = false;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>(); ;
        cleaner = GameObject.FindGameObjectWithTag("Player").transform.Find("Cleaner").GetComponent<Cleaner>();
    }
    private void Update()
    {
        if (canInteract && Input.GetButtonDown("Use"))
        {
            GameObject particle = Instantiate(particles);
            particle.transform.position = player.position;
            dirtness -= cleaner.cleanningKeyRate;
            transform.localScale *= sizingRate;
            if (dirtness <= 0)
            {
                Destroy(this.gameObject);
                manager.dirtCleaned();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canInteract = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canInteract = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
        }
    }
}
