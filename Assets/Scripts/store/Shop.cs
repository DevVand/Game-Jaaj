using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    private Wallet wallet;
    private GameObject player;

    [SerializeField] Color nonInteractiveColor;
    [SerializeField] TextMeshProUGUI coinsText;
    [Header("shop1")]
    [SerializeField] Button button1;
    [SerializeField] TextMeshProUGUI btText1;
    [Header("shop2")]
    [SerializeField] Button button2;
    [SerializeField] TextMeshProUGUI btText2;
    [Header("shop3")]
    [SerializeField] Button button3;
    [SerializeField] TextMeshProUGUI btText3;

    [Header("store config")]
    public float moreSpeedAmount = 15;
    public float moreTurnSpeedAmount = 1.5f;
    [Header("store prices")]
    public int addSucker = 7;
    public int moreSpeed = 5;
    public int moreTurnSpeed = 3;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        wallet = player.GetComponent<Wallet>();
    }
    public void updateMoneyTXT()
    {
        coinsText.text = "money:" + wallet.wallet + "$";
    }

    // STORE ---------------------------------------------------------------------
    public void buyAddSucker(){
        if (wallet.sub(addSucker)){
            button2.interactable = false;
            btText2.color = nonInteractiveColor;
            player.transform.Find("Sucker").gameObject.SetActive(true);
            updateMoneyTXT();
        }
    }
    public void buyMoreSpeed()
    {
        if (wallet.sub(moreSpeed))
        {
            button1.interactable = false;
            btText1.color = nonInteractiveColor;
            player.GetComponent<playerMovement>().speed += moreSpeedAmount;
            updateMoneyTXT();
        }
    }
    public void buyMoreTurnSpeed()
    {
        if (wallet.sub(moreTurnSpeed))
        {
            button3.interactable = false;
            btText3.color = nonInteractiveColor;
            player.GetComponent<playerMovement>().turnSpeed += moreTurnSpeedAmount;
            updateMoneyTXT();
        }
    }
}
