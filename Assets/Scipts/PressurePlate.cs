using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    Vector3 upPos;
    Vector3 downPos;
    public Transform plate;
    public PlateController[] controllers;
    bool on = false;

    public AudioSource pressSnd;

    // Start is called before the first frame update
    void Start()
    {
        upPos = plate.position;
        downPos = plate.position;
        downPos.y -= .132f;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Movement player = collision.GetComponent<Movement>();
        if (player)
        {
            if (!on)
            {
                pressSnd.Play();
                plate.position = downPos;
                foreach (PlateController contr in controllers)
                {
                    contr.TogglePlate(true);
                }
                on = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Movement player = collision.GetComponent<Movement>();
        if (player)
        {
            if (on)
            {
                plate.position = upPos;
                foreach (PlateController contr in controllers)
                {
                    contr.TogglePlate(false);
                }
                on = false;
            }
        }
    }
}
