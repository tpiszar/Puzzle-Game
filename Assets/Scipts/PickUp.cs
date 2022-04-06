using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public CharacterController2D controller;
    public Movement movement;
    public CapsuleCollider2D heldCollider;
    public float range;
    public LayerMask playerMask;
    public LayerMask aboveMask;

    public PickUpController pickContr;
    Transform heldPlayer;
    Vector3 start;
    public Transform end;
    public float endTime;
    float timePassed = 0;

    public bool held;
    public bool holding = false;
    public float upForce;
    public float sideForce;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (holding && pickContr.pickingUp)
        {
            timePassed += Time.deltaTime;
            float amount = timePassed / endTime;
            if (amount < 1)
            {
                heldPlayer.position = Vector3.Lerp(start, end.position, amount);
            }
            else
            {
                heldPlayer.position = end.position;
                pickContr.pickingUp = false;
                timePassed = 0;
            }
        }
    }

    public void TryPickUp()
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
        RaycastHit2D[] hits = new RaycastHit2D[2];
        Physics2D.RaycastNonAlloc(transform.position, facing, hits, range, playerMask);
        RaycastHit2D above = Physics2D.Raycast(transform.position, Vector2.up, 2.2f, aboveMask);
        if (hits[1].collider != null && above.collider == null)
        {
            if (hits[0].transform.name == transform.name)
            {
                heldPlayer = hits[1].transform;
            }
            else
            {
                heldPlayer = hits[0].transform;
            }
            PickUp heldPick = heldPlayer.GetComponent<PickUp>();
            if (!heldPick.holding)
            {
                holding = true;
                pickContr.pickingUp = true;
                start = heldPlayer.position;
                heldPlayer.GetComponentInChildren<Animator>().SetFloat("Speed", 0f);
                heldPlayer.GetComponentInChildren<Animator>().SetBool("Jump", false);
                heldPlayer.GetComponentInChildren<Animator>().Play("Idle");
                heldPick.held = true;
                heldPlayer.GetComponent<Movement>().enabled = false;
                heldPlayer.GetComponent<Collider2D>().enabled = false;
                heldPlayer.GetComponent<CharacterController2D>().enabled = false;
                heldPlayer.GetComponent<Rigidbody2D>().simulated = false;
                heldPlayer.parent = this.transform;
                heldCollider.enabled = true;
            }
        }
    }

    public void Throw()
    {
        heldCollider.enabled = false;
        heldPlayer.GetComponent<PickUp>().held = false;
        heldPlayer.GetComponent<Movement>().enabled = true;
        heldPlayer.GetComponent<Collider2D>().enabled = true;
        heldPlayer.parent = null;
        CharacterController2D otherContr = heldPlayer.GetComponent<CharacterController2D>();
        otherContr.enabled = true;
        otherContr.m_FacingRight = controller.m_FacingRight;
        Rigidbody2D rig = heldPlayer.GetComponent<Rigidbody2D>();
        rig.simulated = true;
        if (controller.m_FacingRight)
        {
            rig.AddForce(new Vector2(sideForce, upForce), ForceMode2D.Impulse);
            //rig.velocity += new Vector2(sideForce, upForce);
        }
        else
        {
            rig.AddForce(new Vector2(-sideForce, upForce), ForceMode2D.Impulse);
        }

        holding = false;
    }
}
