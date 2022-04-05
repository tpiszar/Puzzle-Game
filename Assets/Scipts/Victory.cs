using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{
    public Animation endFade;
    public UnityEngine.UI.Button volBtn;
    public UI vol;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Movement player = collision.GetComponent<Movement>();
        if (player)
        {
            if (vol.volume)
            {
                vol.ToggleVolume();
            }
            volBtn.enabled = false;
            endFade.Play();
        }
    }
}
