using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    Vector3 upPos;
    Vector3 downPos;
    public Transform plate;
    public PlateController controller;
    bool on = false;

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
                plate.position = downPos;
                controller.TogglePlate(true);
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
                controller.TogglePlate(false);
                on = false;
            }
        }
    }
}
