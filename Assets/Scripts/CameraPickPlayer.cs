using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraPickPlayer : MonoBehaviour
{
    CinemachineVirtualCamera cinemachine;
    void Start()
    {
        cinemachine = GetComponent<CinemachineVirtualCamera>();
        Invoke(nameof(pickPlayer), .2f);
    }

    public void pickPlayer() {
        cinemachine.Follow = GameObject.FindGameObjectWithTag("Player").transform;
    }
}
