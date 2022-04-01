using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    [SerializeField]
    public Animation[] blink;
    public float lowRng;
    public float upRng;
    float nextBlink;
    float remaining = 0;

    // Start is called before the first frame update
    void Start()
    {
        nextBlink = Random.Range(lowRng, upRng);
    }

    // Update is called once per frame
    void Update()
    {
        remaining += Time.deltaTime;
        if (remaining > nextBlink)
        {
            foreach (Animation anim in blink)
            {
                anim.Play();
            }
            remaining = 0;
            nextBlink = Random.Range(lowRng, upRng);
        }
    }
}