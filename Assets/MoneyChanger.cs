using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyChanger : MonoBehaviour
{
    private Wallet wallet;
    [SerializeField] TextMeshProUGUI coinsText;
    private void Start()
    {
        wallet = GameObject.FindGameObjectWithTag("Player").GetComponent<Wallet>();
    }
    public void updateMoneyTXT()
    {
        coinsText.text = "money:" + wallet.wallet + "$";
    }
}
