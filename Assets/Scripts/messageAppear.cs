using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class messageAppear : MonoBehaviour
{
    [SerializeField] Light2D light_;
    [SerializeField] Transform lightPos;
    [Header("light")]

    [SerializeField] Transform desappearPos;
    [SerializeField] Transform appearPos;
    [SerializeField] float intensity=1;
    [SerializeField] float range=1;
    [Header("lerp")]
    [SerializeField] float smooth = 10;

    void Update()
    {
        
    }

    public void appear() {
        StopAllCoroutines();
        StartCoroutine(nameof(COappear));
    }
    public void desappear() {
        StopAllCoroutines();
        StartCoroutine(nameof(COdesappear));
    }

    IEnumerator COappear() {
        while (Mathf.Abs(light_.intensity - intensity) > .1f ||
               Mathf.Abs(light_.pointLightOuterRadius - range) > .1f ||
               Vector3.Distance(lightPos.position, appearPos.position) > .05f) {
            lightPos.position = Vector3.Lerp(lightPos.position, appearPos.position, Time.deltaTime * smooth);
            light_.intensity = Mathf.Lerp(light_.intensity, intensity, Time.deltaTime * smooth);
            light_.pointLightOuterRadius= Mathf.Lerp(light_.pointLightOuterRadius, range, Time.deltaTime * smooth);

            yield return null;
        }
        lightPos.position = appearPos.position;
        light_.intensity = intensity;
        light_.pointLightOuterRadius = range;

    }
    IEnumerator COdesappear()
    {
        while (light_.intensity > .1f ||
               light_.pointLightOuterRadius > .1f ||
               Vector3.Distance(lightPos.position, desappearPos.position) > .05f)
        {
            lightPos.position = Vector3.Lerp(lightPos.position, desappearPos.position, Time.deltaTime * smooth);
            light_.intensity = Mathf.Lerp(light_.intensity, 0, Time.deltaTime * smooth);
            light_.pointLightOuterRadius = Mathf.Lerp(light_.pointLightOuterRadius, 0, Time.deltaTime * smooth);

            yield return null;
        }
    }

}
