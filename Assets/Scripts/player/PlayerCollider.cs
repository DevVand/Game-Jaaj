using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    private playerManager player;
    private Animator anim;
    private playRandomSound playSound;
    public float recoveryRate = 1;
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GetComponent<playerManager>();
        playSound = transform.Find("Hit Sounds").GetComponent<playRandomSound>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        playSound.playRandom();
        anim.Play("alert", 1);
        player.disablePlayerMovement();
        player.Invoke(nameof(player.enablePlayerMovement), recoveryRate);
    }
}
