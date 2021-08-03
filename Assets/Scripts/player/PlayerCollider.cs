using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    private playerManager player;
    private Animator anim;
    private playRandomSound playSound;
    private playRandomSound playFSound;
    public float recoveryRate = 1;
    public float fuckChance = .02f;
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GetComponent<playerManager>();
        playSound = transform.Find("Hit Sounds").GetComponent<playRandomSound>();
        playFSound = transform.Find("Fuck Sound").GetComponent<playRandomSound>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Random.value < fuckChance)
            Invoke(nameof(playFuck), .1f);
        playSound.playRandom();
        anim.Play("alert", 1);
        player.disablePlayerMovement();
        player.Invoke(nameof(player.enablePlayerMovement), recoveryRate);
    }
    public void playFuck()
    {
        playFSound.playRandom();
    }
}
