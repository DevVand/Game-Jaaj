using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryCharge : MonoBehaviour
{
    public float smooth = 4;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Battery battery = collision.gameObject.GetComponent<Battery>();
            battery.charging = true; 
            battery.charge();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
        {
        if (collision.gameObject.tag == "Player")
        {
            Battery battery = collision.gameObject.GetComponent<Battery>();
            battery.charging = false; 
            battery.Invoke(nameof(battery.drain), battery.drainRate);
            
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
