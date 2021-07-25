using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battery : MonoBehaviour
{
    public float actualCharge = 100;
    public float maxCharge = 100;
    public float drainAmount = 10;
    public float chargeAmount = 1;
    public float drainRate = 2;

    [SerializeField] Slider slider;
    [SerializeField] Image img;
    public Color green;
    public Color yellow;
    public Color red;

    void Start()
    {
        actualCharge = maxCharge;
        slider.maxValue = maxCharge;
        slider.value = maxCharge;
        Invoke(nameof(drain), drainRate);
    }


    void Update()
    {
        slider.value = Mathf.Lerp(slider.value, actualCharge,4*Time.deltaTime);

        img.color = Color.Lerp(img.color, getColor(actualCharge), 3 * Time.deltaTime);
    }
    public void drain() {
        actualCharge = Mathf.Max(actualCharge - drainAmount,0);
        Invoke(nameof(drain), drainRate);
    }
    public void charge()
    {
        actualCharge = Mathf.Min(actualCharge+chargeAmount,maxCharge);
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
