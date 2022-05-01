using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class UIButtons : MonoBehaviour
{
    public GameObject settingsMenu;
    private bool settingsOnScreen;
    public GameObject MainManager;

    public GameObject SaveGameButton;
    public GameObject ExitGameButton;

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

    public void saveTotal()
    {
        MainManager.GetComponent<MainManager>().savePlayerData();
    }
    
    public void ExitGame()
    {
        SceneManager.LoadScene(0); 
    }
}
