using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateController : MonoBehaviour
{
    public int platesRequired;
    int platesOn = 0;
    bool on = true;
    bool transitioning = false;
    public Transform platform;
    public Transform start;
    public Transform end;
    public float endTime;
    float timePassed = 0;

    void Update()
    {
        if (transitioning)
        {
            timePassed += Time.deltaTime;
            float amount = timePassed / endTime;
            if (amount < 1)
            {
                if (on)
                {
                    platform.position = Vector3.Lerp(end.position, start.position, amount);
                }
                else
                {
                    platform.position = Vector3.Lerp(start.position, end.position, amount);
                }
            }
            else
            {
                transitioning = false;
                timePassed = 0;
            }
        }
    }

    public void TogglePlate(bool plateOn)
    {
        if (plateOn)
        {
            platesOn++;
            if (platesOn == platesRequired)
            {
                if (transitioning)
                {
                    timePassed = endTime - timePassed;
                }
                transitioning = true;
                on = false;
            }
        }
        else
        {
            if (platesOn == platesRequired)
            {
                if (transitioning)
                {
                    timePassed = endTime - timePassed;
                }
                transitioning = true;
                on = true;
            }
            platesOn--;
        }
    }
}
