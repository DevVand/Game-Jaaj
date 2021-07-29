using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaner : MonoBehaviour
{
    private GameManager manager;
    public float cleanningKeyRate = 1;
    public float cleanningStandRate = .02f;
    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>(); ;
    }
    public void start()
    {
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>(); ;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Dust") {
            if (collision.GetComponent<CarpetDust>() == null)
            {
                LiquidDust liquid = collision.GetComponent<LiquidDust>();
                if (liquid != null)
                {
                    liquid.clean();
                }
                else
                {

                    manager.dirtCleaned();
                    Destroy(collision.gameObject);
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Dust")
        {
            LiquidDust liquid = collision.GetComponent<LiquidDust>();
            if (liquid != null)
            {
                liquid.stopClean();
            }
        }
    }
}
