using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

public class ControllerManager : MonoBehaviour
{
    public GameObject enterButton;
    public GameObject aButton;
    public GameObject xbutton;

    public DialogueManager dm;

    void OnEnable()
    {
        InputUser.onChange += OnInputDeviceChange;
    }

    void OnDisable()
    {
        InputUser.onChange -= OnInputDeviceChange;
    }

    void OnInputDeviceChange(InputUser user, InputUserChange change, InputDevice device)
    {
        if (change == InputUserChange.ControlSchemeChanged)
        {
            UpdateButtonImage(user.controlScheme.Value.name);
        }
    }

    public void UpdateButtonImage(string schemeName)
    {
        if (dm.canSkip)
        {
            if (schemeName.Equals("PS"))
            {
                enterButton.SetActive(false);
                aButton.SetActive(false);
                xbutton.SetActive(true);
            }
            else if (schemeName.Equals("Xbox"))
            {
                enterButton.SetActive(false);
                aButton.SetActive(true);
                xbutton.SetActive(false);
            }
            else if (schemeName.Equals("Keyboard"))
            {
                enterButton.SetActive(true);
                aButton.SetActive(false);
                xbutton.SetActive(false);
            }
        }
    }
}
