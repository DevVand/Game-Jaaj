using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCleaning : MonoBehaviour
{
    private GameManager manager;

    private GameObject player;
    public Transform pos;
    public float angle = 0;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.GetComponent<playerManager>().disablePlayerMovement();
            //ask if wants to end game
            manager.endGame();
        }
    }

    //reset when not done
    public void stillCleaning()
    {
        player.transform.position = pos.position;
        player.GetComponent<playerMovement>().angle=angle;
        player.GetComponent<playerManager>().enablePlayerMovement();
    }
}
