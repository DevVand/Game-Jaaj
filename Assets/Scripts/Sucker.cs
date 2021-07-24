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
            Rigidbody2D rdbd = collision.gameObject.GetComponent<Rigidbody2D>();

            Vector2 dir = transform.position-collision.transform.position;
            float strength = Mathf.Min(200,((9.8f * 10 * 1) / (dir.magnitude * dir.magnitude)))*speed;

            dir=dir.normalized;
            
            dir*=strength;
            rdbd.velocity += dir * Time.deltaTime;

            //collision.gameObject.transform.position =
                //Vector3.Lerp(collision.transform.position, transform.position,
                //speed * Time.deltaTime);
        }
    }
}
