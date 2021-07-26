using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GradeChanger : MonoBehaviour
{


    private GameManager manager;
    public float timer = 0;

    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }
    public void startRoll() { timer = 0; StartCoroutine(nameof(roll)); }
    public void endRoll() { StopAllCoroutines(); manager.getGrade(); }

    IEnumerator roll() {
        while (true)
        {
            manager.getRandomGrade();
            yield return new WaitForSeconds(timer);
        }
    }
}
