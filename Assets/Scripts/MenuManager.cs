using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    public string cafeName;
    public bool newGame = false;
    public InputField inputField;

    public void Awake()
    {
        if (Instance = null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetCafeName()
    {
        cafeName = inputField.text;
    }

    public void setNewGameTrue()
    {
        newGame = true;
    }


}
