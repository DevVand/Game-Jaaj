using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryCharge : MonoBehaviour
{
    public float smooth = 4;
    public bool spawnHere = false;
    public float spawnAngle = 0;

    private void Start()
    {
        if (spawnHere) {
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject player in players)
            {
                player.transform.position = transform.position;
                player.GetComponent<playerMovement>().angle = -spawnAngle;
            } 
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Battery>().startCharging();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
        {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Battery>().stopCharging();
            
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            if (Input.GetAxis("Vertical") == 0)
            {
                collision.gameObject.transform.position = Vector3.Lerp(
                collision.gameObject.transform.position, transform.position,
                smooth * Time.deltaTime);
                //collision.gameObject.GetComponent<Battery>().charge();
            }
        }
    }
}
