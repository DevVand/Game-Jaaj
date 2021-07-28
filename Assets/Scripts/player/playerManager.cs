using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager : MonoBehaviour
{
    public bool original = false;
    private GameObject player;
    void Start()
    {
        DontDestroyOnLoad(this);
        if (GameObject.FindGameObjectsWithTag("Player").Length > 1)
        {
            if (!original)
            {
                DestroyImmediate(this.gameObject, true); ;
            }
        }
        player = GameObject.FindGameObjectWithTag("Player");
        original = true;
    }

    public void disablePlayerMovement()
    {
        player.GetComponent<playerMovement>().enabled = false;

    }
    public void enablePlayerMovement()
    {
        playerMovement playerMovement = player.GetComponent<playerMovement>();
        playerMovement.enabled = true;
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
