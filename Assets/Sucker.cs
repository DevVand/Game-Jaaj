using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sucker : MonoBehaviour
{
    public float speed = 2;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Dust")
        {
            collision.gameObject.transform.position =
                Vector3.Lerp(collision.transform.position, transform.position,
                speed * Time.deltaTime);
        }
    }
}
