using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    private JSONSaving jsonSaving;
    
    private string m_cafeName;
    private bool newGame;
    
    private PlayerData playerData;

    [SerializeField]
    public GameObject totalText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("Trying to Save File...");
            jsonSaving.SaveData(playerData);
            
        }
    }

    public void Awake()
    {
        jsonSaving = new JSONSaving();
        
        m_cafeName = MenuManager.Instance.cafeName;
        newGame = MenuManager.Instance.newGame;
        
        if (newGame)
        {
            CreateNewPlayerData(m_cafeName);
            jsonSaving.SetPaths(m_cafeName);
            Debug.Log("The cafe " + m_cafeName + " has been created.");
        }
        else
        {
            jsonSaving.SetPaths(m_cafeName);
            playerData = jsonSaving.LoadData();
            Debug.Log(playerData);
        }
    }
    
    private void CreateNewPlayerData(string name)
    {
        playerData = new PlayerData(name, 0, 0);
    }

    public void savePlayerData()
    {
        double total = totalText.GetComponent<ProfitsTracker>().getTotalProfit();
        playerData.updateTotal(total);
        jsonSaving.SaveData(playerData);
    }

    

}
