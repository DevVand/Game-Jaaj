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

    [SerializeField] Timer timer;
    [SerializeField] Animator animFade;
    [SerializeField] Animator animFade2;
    [SerializeField] Animator animTimerMessage;
    [SerializeField] Animator animFinalMessage;
    [SerializeField] TextMeshProUGUI endText;
    [SerializeField] TextMeshProUGUI coinsText;
    [SerializeField] Slider percentageSlider;

    public int min = 60;
    public int med = 80;
    public int max = 90;

    public int dirts = 0;
    float percentageOfOne = 0;
    float percentage = 0;
    Grades grades;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.transform.Find("Cleaner").gameObject.GetComponent<Cleaner>().start();
        player.GetComponent<playerMovement>().enabled = true;
        player.GetComponent<playerManager>().enableCollider();

        grades = GetComponent<Grades>();
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Dust");
        foreach (GameObject obj in objects)
        {
            dirts++;
        }
        percentageOfOne = 1 * 100 / dirts;

    }

    private void Update()
    {
        percentageSlider.value = Mathf.Lerp(percentageSlider.value, percentage, 5 * Time.deltaTime);
    }
    public void dirtCleaned()
    {
        percentage += percentageOfOne;
        if (percentage >= 98) {
            endGame();
        }
    }

    public void getGrade()
    {
        Wallet wallet = player.GetComponent<Wallet>();
        if (percentage > max)
        {
            endText.text = grades.gradeA();
            coinsText.text = "+15$";
            wallet.add(15);
        }
        else if (percentage > med)
        {
            endText.text = grades.gradeB();
            coinsText.text = "+10$";
            wallet.add(10);
        }
        else if (percentage > min)
        {
            endText.text = grades.gradeC();
            coinsText.text = "+5$";
            wallet.add(5);
        }

    }
    /*
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

    }*/
    public void getRandomGrade()
    {
        endText.text = grades.gradeRandom();
    }
    public void timerEnded() {
        playerManager manager = player.GetComponent<playerManager>();
        manager.disablePlayerMovement();
        manager.disableCollider();
        animFade.SetBool("fade", false);
        if (percentage < min)
        {
            animTimerMessage.Play("end");
        } else {
            endGame();
        }
    }
    public void endGame()
    {
        timer.timerIsRunning = false;
        animFade.SetBool("fade", false);
        Invoke(nameof(startEndAnimation), 1.3f);
    }

    public void startEndAnimation()
    {
        animFinalMessage.Play("end");
    }
    public void Continue() {
        animFade2.SetBool("fade", false);
        Invoke(nameof(loadScene), 1.3f);
    }
    public void Retry()
    {
        animFade2.SetBool("fade", false);
        Invoke(nameof(loadThisScene), 1.3f);
    }
    public void loadScene()
    {
        SceneManager.LoadScene(nextScene);
    }
    public void loadThisScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
