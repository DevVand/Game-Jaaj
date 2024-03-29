﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battery : MonoBehaviour
{
    private playerMovement player;

    public float actualCharge = 100;
    public float maxCharge = 100;
    public float drainAmount = 10;
    public float chargeAmount = 5;
    public float drainRate = 2;
    public float chargeRate = .5f;

    private bool wasCharging = true;
    public bool charging = true;


    [SerializeField] Animator batteryAnim;
    [SerializeField] Slider slider;
    [SerializeField] Image img;
    public Color green;
    public Color yellow;
    public Color red;

    void Start()
    {
        player = GetComponent<playerMovement>();
        actualCharge = maxCharge;
        slider.maxValue = maxCharge;
        slider.value = maxCharge;
        //Invoke(nameof(drain), drainRate);
    }


    void Update()
    {
        if (actualCharge <= 0)
        {
            batteryAnim.Play("alert");
            player.slowMode = true;
        }
        else {
            batteryAnim.Play("idle");
            player.slowMode = false;
        }

        slider.value = Mathf.Lerp(slider.value, actualCharge,4*Time.deltaTime);
        img.color = Color.Lerp(img.color, getColor(actualCharge), 3 * Time.deltaTime);
    }



    public void startCharging()
    {
        CancelInvoke(nameof(drain));
        CancelInvoke(nameof(charge));

        charging = true;
        charge();
    }

    public void stopCharging()
    {
        CancelInvoke(nameof(drain));
        CancelInvoke(nameof(charge));

        charging = false;
        Invoke(nameof(drain), drainRate);
    }

    public void drain() {
        if (!charging)
        {
            actualCharge = Mathf.Max(actualCharge - drainAmount, 0);
            Invoke(nameof(drain), drainRate);
        }
    }
    public void charge()
    {
        if (charging)
        {
            actualCharge = Mathf.Min(actualCharge + chargeAmount, maxCharge);
            Invoke(nameof(charge), chargeRate);
        }
    }
    public void addMmaxCharge(int amount) {
        maxCharge += amount;
        slider.maxValue = maxCharge;
    }
    public Color getColor(float amount) {
        Color color;
        if (amount > 75)
            color = green;
        else if (amount > 35)
            color = yellow;
        else
            color = red;
        return color;
    }
}
