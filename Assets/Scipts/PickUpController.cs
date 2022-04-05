using UnityEngine;

public class PickUpController : MonoBehaviour
{
    bool hold = false;
    public bool pickingUp = false;
    [SerializeField]
    PickUp[] players;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (hold && !pickingUp)
            {
                foreach (PickUp player in players)
                {
                    if (player.holding)
                    {
                        player.Throw();
                    }
                }
                hold = false;
            }
            else
            {
                bool ltr = players[0].GetComponent<CharacterController2D>().m_FacingRight;
                SortX();
                if (ltr)
                {
                    foreach (PickUp player in players)
                    {
                        if (!player.held)
                        {
                            player.TryPickUp();
                        }
                    }
                }
                else
                {
                    for (int i = players.Length - 1; i >= 0; i--)
                    {
                        if (!players[i].held)
                        {
                            players[i].TryPickUp();
                        }
                    }
                }
                foreach (PickUp player in players)
                {
                    if (player.held)
                    {
                        hold = true;
                        break;
                    }
                }
            }
        }
    }

    void SortX()
    {
        for (int i = 1; i < players.Length; i++)
        {
            for (int j = i; j >= 1; j--)
            {
                float prev = players[j - 1].transform.position.x;
                float cur = players[j].transform.position.x;
                if (cur < prev)
                {
                    PickUp temp = players[j - 1];
                    players[j - 1] = players[j];
                    players[j] = temp;
                }
                else
                {
                    break;
                }
            }
        }
    }
}
