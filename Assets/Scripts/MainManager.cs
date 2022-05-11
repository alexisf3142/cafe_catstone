using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    private JSONSaving jsonSaving;

    private string m_cafeName;
    private bool newGame;

    private PlayerData playerData;

    [SerializeField] public GameObject totalText;
    [SerializeField] public GameObject coffeeServedText;

    public GameObject cupTotal;

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
            //loading in data
            totalText.GetComponent<ProfitsTracker>().setTotalProfit((float) playerData.money);
            cupTotal.GetComponent<coffeeServed>().setCoffeesServed(playerData.coffeeServed);
            //update day here with playerData.day --------------------------------------

            Debug.Log(playerData);
        }
    }

    public int GetDay()
    {
        return playerData.day;
    }

    private void CreateNewPlayerData(string name)
    {
        playerData = new PlayerData(name, 0, 0, 0);
    }

    public void savePlayerData()
    {
        double total = totalText.GetComponent<ProfitsTracker>().getTotalProfit();
        //int totalCups = cupTotal.GetComponent<coffeeServed>().getCoffeesServed();
        Debug.Log(playerData);
        playerData.updateTotal(total);
        var cupsServed = Int32.Parse(cupTotal.GetComponent<Text>().text);
        playerData.updateCoffeeServed(cupsServed);
        Debug.Log("CUPS =" +cupsServed);
        jsonSaving.SaveData(playerData);
    }
    
    public void savePlayerData_EndOfDay()
    {
        double total = totalText.GetComponent<ProfitsTracker>().getTotalProfit();
        //int totalCups = cupTotal.GetComponent<coffeeServed>().getCoffeesServed();
        Debug.Log(playerData);
        playerData.updateTotal(total);
        var cupsServed = Int32.Parse(cupTotal.GetComponent<Text>().text);
        playerData.updateCoffeeServed(cupsServed);
        Debug.Log("CUPS =" +cupsServed);
        playerData.updateDay(playerData.day + 1);
        jsonSaving.SaveData(playerData);
    }

    

}
