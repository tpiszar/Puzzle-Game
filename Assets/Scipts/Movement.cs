using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController2D controller;
    //public Rigidbody2D rig;

    public float speed = 50f;
    bool jump = false;
    float move = 0f;

    public Animator animator;

    void Update()
    {
        move = Input.GetAxisRaw("Horizontal");

        //if (!controller.m_FacingRight)
        //{
        //    move *= -1;
        //}

        animator.SetFloat("Speed", Mathf.Abs(move));
        animator.SetBool("Jump", !controller.m_Grounded);

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    void FixedUpdate()
    {
        if (controller.m_Grounded)
        {
            if (jump)
            {
                animator.Play("Jump");
            }
        }
        controller.Move(move * speed * Time.deltaTime, jump);
        //else
        //{
        //    controller.Move(move * airSpd * Time.deltaTime, jump);
        //}

        jump = false;
    }
}
