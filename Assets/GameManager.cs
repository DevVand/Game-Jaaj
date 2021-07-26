using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour
{

    [SerializeField] Animator animFade;
    [SerializeField] Animator animFinalMessage;
    [SerializeField] TextMeshProUGUI endText;

    public int dirts = 0;
    private Grades grades;
    
    void Start()
    {
        grades = GetComponent<Grades>();
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Dust");
        foreach (GameObject obj in objects)
        {
            dirts++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void endGame() {
        animFade.SetBool("fade", false);
        Invoke(nameof(startEndAnimation), 1.3f);
    }

    public void startEndAnimation() {
        animFinalMessage.Play("end");
    }

    public void getGrade() {
        endText.text = grades.gradeRandom();
    }
    public void getRandomGrade()
    {
        endText.text = grades.gradeRandom();
    }
}
