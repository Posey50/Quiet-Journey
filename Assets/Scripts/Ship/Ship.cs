using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public StateManager sm;
    public bool isNextShip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (isNextShip)
            {
                sm.SwitchNextLvl();
            }
            else
            {
                sm.SwitchPreviousLvl();
            }
        }
    }
}
