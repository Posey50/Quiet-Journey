using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SwitchButton : MonoBehaviour
{
    public StateManager stateManager;

    public void SwitchNextLvl()
    {
        //check if the next index is not the last in the list
        if (stateManager.i + 1 <= stateManager.iMax)
        {
            //go to the next state
            stateManager.i++;
            stateManager.switchState();
        }

        //check if next state is note superior to iMax
        if (stateManager.i + 1 > stateManager.iMax)
        {
            return;
        }
    }

    public void SwitchPreviousLvl()
    {
        //check if the next index is not the last in the list
        if (stateManager.i - 1 >= 0)
        {
            //go to the next state
            stateManager.i--;
            stateManager.switchState();
        }

        //check if next state is not lower to iMax
        else if (stateManager.i + 1 < 0)
        {
            return;
        }
    }
}