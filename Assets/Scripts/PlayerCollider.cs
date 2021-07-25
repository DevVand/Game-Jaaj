using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    private playerManager player;
    private Animator anim;
    public float timer = 1;
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GetComponent<playerManager>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        anim.Play("alert", 1);
        player.disablePlayerMovement();
        player.Invoke(nameof(player.enablePlayerMovement), timer);
    }
}
