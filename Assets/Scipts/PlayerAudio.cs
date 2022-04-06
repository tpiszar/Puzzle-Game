using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public static bool playJump = false;
    public AudioSource jump;

    void Update()
    {   
        if (playJump)
        {
            jump.Play();
            playJump = false;
        }
    }
}
