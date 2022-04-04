using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{
    public Animation endFade;
    private void OnTriggerEnter(Collider other)
    {
        print("Collides");
        Movement player = other.GetComponent<Movement>();
        if (player)
        {
            print("Victory");
            endFade.Play();
        }
    }
}
