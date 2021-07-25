using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryCharge : MonoBehaviour
{
    public float smooth = 4;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
            {
                collision.gameObject.transform.position = Vector3.Lerp(
                collision.gameObject.transform.position, transform.position,
                smooth * Time.deltaTime); ;
                collision.gameObject.GetComponent<Battery>().charge();
            }
        }
    }
}
