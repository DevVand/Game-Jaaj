using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteerTowardsPlayer : MonoBehaviour
{

    private playerMovement player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovement>(); ;
    }
    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = new Vector3(0, 0, player.angle + 90 + 180);
    }
}
