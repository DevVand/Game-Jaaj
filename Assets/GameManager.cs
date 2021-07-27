using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    private GameObject player;

    public string nextScene;

    [SerializeField] Animator animFade;
    [SerializeField] Animator animFinalMessage;
    [SerializeField] TextMeshProUGUI endText;
    [SerializeField] TextMeshProUGUI coinsText;

    public int dirts = 0;
    private Grades grades;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        grades = GetComponent<Grades>();
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Dust");
        foreach (GameObject obj in objects)
        {
            dirts++;
        }
    }

    public void endGame() {
        animFade.SetBool("fade", false);
        Invoke(nameof(startEndAnimation), 1.3f);
    }

    public void startEndAnimation() {
        animFinalMessage.Play("end");
    }

    public void getGrade() {

        GameObject[] objects = GameObject.FindGameObjectsWithTag("Dust");
        int dirtLeft = 0;
        foreach (GameObject obj in objects)
        {
            dirtLeft++;
        }
        int dirtDone = dirts - dirtLeft;
        float percentage = dirtDone * 100 / dirts;

        Wallet wallet = player.GetComponent<Wallet>();
        if (percentage > 90) {
            endText.text = grades.gradeA();
            coinsText.text = "+15$";
            wallet.add(15);
        }else if (percentage > 40){
            endText.text = grades.gradeB();
            coinsText.text = "+10$";
            wallet.add(10);
        }else{
            endText.text = grades.gradeC();
            coinsText.text = "+5$";
            wallet.add(5);
        }

    }
    public void getRandomGrade()
    {
        endText.text = grades.gradeRandom();
    }
    public void NextScene() {
        SceneManager.LoadScene(nextScene);
    }
}
