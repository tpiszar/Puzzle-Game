using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickLever : MonoBehaviour
{
    public CharacterController2D controller;
    public float range;
    public LayerMask mask;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Vector2 facing;
            if (controller.m_FacingRight)
            {
                facing = Vector2.right;
            }
            else
            {
                facing = Vector2.left;
            }
            RaycastHit2D ray = Physics2D.Raycast(transform.position, facing, range, mask);

            if (ray)
            {
                ray.rigidbody.gameObject.GetComponent<Lever>().ToggleLever();
            }
        }
    }
}
