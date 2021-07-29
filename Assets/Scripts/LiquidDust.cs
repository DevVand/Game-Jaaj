using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidDust : MonoBehaviour
{
    GameManager manager;
    Cleaner cleaner;
    public GameObject particles;
    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>(); ;
        cleaner = GameObject.FindGameObjectWithTag("Player").transform.Find("Cleaner").GetComponent<Cleaner>();
    }

    public void clean() {
        StartCoroutine(nameof(startCleanning));
    }
    public void stopClean()
    {
        StopAllCoroutines();
    }

    IEnumerator startCleanning() {
        while (true) {
            float rate = cleaner.cleanningStandRate;
            transform.localScale -= new Vector3(rate, rate, rate);
            if (transform.localScale.x < .45f)
            {
                manager.dirtCleaned();
                GameObject particle = Instantiate(particles);
                particle.transform.position = transform.position;
                Destroy(this.gameObject);
            }
            yield return new WaitForSeconds(0.01f);
        }
    }
}
