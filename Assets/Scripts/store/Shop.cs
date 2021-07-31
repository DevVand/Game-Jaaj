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
    public int moreBatteryAmount = 15;
    public float moreStunResistanceAmount = .5f;
    public float moreChargeSpeed = .3f;
    public float moreSuctionRadius = 1.4f;
    public float moreSuctionForce = .4f;

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
    public void buyNothing(int price)
    {
        if (wallet.sub(price))
        {
            disableBT2();
            updateMoneyTXT();
        }
    }
    public void buyAddSucker(int price)
    {
        if (wallet.sub(price)){
            disableBT2();
            player.transform.Find("Sucker").localScale = new Vector3(1,1,1);
            updateMoneyTXT();
        }
    }
    public void buyAddDash(int price)
    {
        if (wallet.sub(price))
        {
            disableBT2();
            player.GetComponent<playerMovement>().dashUnlocked = true; ;
            updateMoneyTXT();
        }
    }
    public void buyMoreSpeed(int price)
    {
        if (wallet.sub(price))
        {
            disableBT1();
            player.GetComponent<playerMovement>().speed += moreSpeedAmount;
            updateMoneyTXT();
        }
    }
    public void buyMoreTurnSpeed(int price)
    {
        if (wallet.sub(price))
        {
            disableBT3();
            player.GetComponent<playerMovement>().turnSpeed += moreTurnSpeedAmount;
            updateMoneyTXT();
        }
    }
    public void buyMoreStunResistance(int price)
    {
        if (wallet.sub(price))
        {
            disableBT1();
            player.GetComponent<PlayerCollider>().recoveryRate -= moreStunResistanceAmount;
            updateMoneyTXT();
        }
    }
    public void buyMoreBattery(int price)
    {
        if (wallet.sub(price))
        {
            disableBT3();
            player.GetComponent<Battery>().addMmaxCharge(moreBatteryAmount);
            updateMoneyTXT();
        }
    }
    public void buyMoreChargeSpeed(int price)
    {
        if (wallet.sub(price))
        {
            disableBT3();
            player.GetComponent<Battery>().chargeAmount += moreChargeSpeed;
            updateMoneyTXT();
        }
    }
    public void buyMoreSuctionForce(int price)
    {
        if (wallet.sub(price))
        {
            disableBT2();
            player.transform.Find("Sucker").GetComponent<Sucker>().speed += moreSuctionForce;
            updateMoneyTXT();
        }
    }
    public void buyMoreSuctionRadius(int price)
    {
        if (wallet.sub(price))
        {
            disableBT2();
            Transform sucker = player.transform.Find("Sucker");
            sucker.localScale = new Vector3(sucker.localScale.x * moreSuctionRadius, sucker.localScale.y * moreSuctionRadius, 1); ;
            updateMoneyTXT();
        }
    }

    void disableBT1()
    {
        button1.interactable = false;
        btText1.color = nonInteractiveColor;
    }
    void disableBT2()
    {
        button2.interactable = false;
        btText2.color = nonInteractiveColor;
    }
    void disableBT3()
    {
        button3.interactable = false;
        btText3.color = nonInteractiveColor;
    }
}
