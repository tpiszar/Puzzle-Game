using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public static bool playJump = false;
    public static bool playThrow = false;
    public static bool playPick = false;
    public AudioSource jumpSnd;
    public AudioSource throwSnd;
    public AudioSource pickSnd;

    void Update()
    {   
        if (playJump)
        {
            jumpSnd.Play();
            playJump = false;
        }
        if (playThrow)
        {
            throwSnd.Play();
            playThrow = false;
        }
        if (playPick)
        {
            pickSnd.Play();
            playPick = false;
        }
    }
}
