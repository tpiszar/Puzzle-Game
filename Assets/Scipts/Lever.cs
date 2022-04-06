using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public Transform lever;
    [SerializeField]
    bool on = true;
    bool transitioning = false;
    public Transform platform;
    public Transform start;
    public Transform end;
    public float endTime;
    float timePassed = 0;
    public float delay;
    float delayTime = 0;

    public AudioSource flickSnd;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transitioning)
        {
            delayTime -= Time.deltaTime;
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

    public void ToggleLever()
    {
        if (delayTime > 0)
        {
            return;
        }
        if (flickSnd != null)
        {
            flickSnd.Play();
        }
        if (transitioning)
        {
            timePassed = endTime - timePassed;
        }
        if (on)
        {
            lever.Rotate(new Vector3(0, 0, -90));
            on = false;
            transitioning = true;
            delayTime = delay;
        }
        else
        {
            lever.Rotate(new Vector3(0, 0, 90));
            on = true;
            transitioning = true;
            delayTime = delay;
        }
    }
}
