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
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        wallet = player.GetComponent<Wallet>();
    }

    public void buyAddSucker(){
        if (wallet.sub(5)){
            button2.interactable = false;
            btText2.color = nonInteractiveColor;
            player.transform.Find("Sucker").gameObject.active = true;
            updateMoneyTXT();
        }
    }

    public void updateMoneyTXT()
    {
        coinsText.text = "money:" + wallet.wallet + "$";
    }
}
