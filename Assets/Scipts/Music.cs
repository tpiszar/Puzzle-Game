using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioSource music1;
    public AudioSource music2;
    float length1;
    float length2;
    bool song1 = true;

    void Start()
    {
        music1.Play();
        length1 = music1.clip.length - 1;
        length2 = music2.clip.length + 1;
        DontDestroyOnLoad(this.gameObject);
        Invoke("SwitchMusic", length1);
    }


    void SwitchMusic()
    {
        if (song1)
        {
            music1.Stop();
            music2.Play();
            Invoke("SwitchMusic", length2);
        }
        else
        {
            music2.Stop();
            music1.Play();
            Invoke("SwitchMusic", length1);
        }
    }
}
