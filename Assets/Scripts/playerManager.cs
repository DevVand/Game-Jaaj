using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager : MonoBehaviour
{

    private GameObject player;
    private Animator anim;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = player.GetComponent<Animator>();
    }

    public void disablePlayerMovement()
    {
        player.GetComponent<playerMovement>().enabled = false;
        //player.GetComponent<lightManager>().enabled = false;
        //player.GetComponent<Rigidbody2D>().isKinematic = true;

    }
    public void enablePlayerMovement()
    {
        playerMovement playerMovement = player.GetComponent<playerMovement>();
        playerMovement.enabled = true;
        //player.GetComponent<Rigidbody2D>().isKinematic = false;
    }
    public void invisible()
    {
        SpriteRenderer playerColor = player.GetComponent<SpriteRenderer>();
        playerColor.color = new Color(playerColor.color.r, playerColor.color.g, playerColor.color.b, 0);
    }
    public void visible()
    {
        SpriteRenderer playerColor = player.GetComponent<SpriteRenderer>();
        playerColor.color = new Color(playerColor.color.r, playerColor.color.g, playerColor.color.b, 1);
    }
    public void disableCollider()
    {
        player.GetComponent<Collider2D>().isTrigger = true;
    }
    public void enableCollider()
    {
        player.GetComponent<Collider2D>().isTrigger = false;
    }
   
    public void resetVelocity() {
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }
   
}
