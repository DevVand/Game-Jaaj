using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBool_Animator : MonoBehaviour
{
    public string animation = "fade";
    public bool state = true;
    void Start()
    {
        GetComponent<Animator>().SetBool(animation, state);
    }
}
