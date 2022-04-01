using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public Transform lever;
    [SerializeField]
    bool on = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleLever()
    {
        print("Toggled");
        if (on)
        {
            lever.Rotate(new Vector3(0, 0, -90));
            on = false;
        }
        else
        {
            lever.Rotate(new Vector3(0, 0, 90));
            on = true;
        }
    }
}
