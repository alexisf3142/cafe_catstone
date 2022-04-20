using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtons : MonoBehaviour
{
    public GameObject settingsMenu;
    private bool settingsOnScreen;

    private void Start()
    {
        settingsMenu.SetActive(false);
        settingsOnScreen = false;
    }

    public void toggleSettings()
    {
        Debug.Log("Settings!");
        if (settingsOnScreen)
        {
            settingsMenu.SetActive(false);
            settingsOnScreen = false;
        }
        else
        {
            settingsMenu.SetActive(true);
            settingsOnScreen = true;
        }
    }
}
