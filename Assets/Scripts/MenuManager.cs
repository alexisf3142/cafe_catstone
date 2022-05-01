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
    public GameObject DropDown;
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
    
    public bool LoadCafeName()
    {
        cafeName = DropDown.GetComponent<DropdownHandler>().getSelectedSave();
        if (cafeName == "Choose Save")
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void setNewGameTrue()
    {
        newGame = true;
    }


}
