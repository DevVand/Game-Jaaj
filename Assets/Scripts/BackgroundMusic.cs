using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    AudioSource source;
    public bool on = false;
    public float smooth = .2f;
    
    public bool original = false;
    void Start()
    {
        DontDestroyOnLoad(this);
        if (GameObject.FindGameObjectsWithTag("BGMusic").Length > 1)
        {
            if (!original)
            {
                DestroyImmediate(this.gameObject, true); ;
            }
        }
        original = true;

        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (on)
        {
            source.volume = Mathf.Lerp(source.volume, 1, smooth * Time.deltaTime);
        } else {
            source.volume = Mathf.Lerp(source.volume, 0, 4 * smooth * Time.deltaTime);
        }
    }
}
