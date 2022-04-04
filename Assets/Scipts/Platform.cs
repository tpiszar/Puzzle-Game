using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Movement player = collision.GetComponent<Movement>();
        if (player)
        {
            player.transform.parent = this.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Movement player = collision.GetComponent<Movement>();
        if (player && player.transform.parent == this.transform)
        {
            player.transform.parent = null;
        }
    }
}
