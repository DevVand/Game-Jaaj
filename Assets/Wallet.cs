using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    public int wallet = 0;

    public bool sub(int amount){
        if (wallet - amount >= 0) {
            wallet -= amount;
            return true;
        }else
            return false;
    }
    public void add(int amount)
    {
        wallet += amount;
    }
}
