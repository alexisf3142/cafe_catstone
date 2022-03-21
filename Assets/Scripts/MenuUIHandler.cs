using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    public GameObject titleScreen;

    public void StartNew()
    {
        MenuManager.Instance.SetCafeName();
        titleScreen.SetActive(false);
        SceneManager.LoadScene(1);
    }
}
