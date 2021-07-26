using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticles : MonoBehaviour
{
    private playerMovement movement;

    [SerializeField] ParticleSystem dashParticle;
    void Start()
    {
        movement = GetComponent<playerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (movement.dashing) {
            dashParticle.enableEmission = true;
            dashParticle.transform.eulerAngles = new Vector3(0, 0, movement.angle-90);
        }
        else {
            dashParticle.enableEmission = false;
        }
    }
}
