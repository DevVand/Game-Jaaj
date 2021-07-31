using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseLantern : MonoBehaviour
{
    GameObject lantern;
    void Start()
    {
        lantern = GameObject.FindGameObjectWithTag("Player").transform.Find("Lantern").gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            lantern.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            lantern.SetActive(false);
        }
    }
}