using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfitsTracker : MonoBehaviour
{

    private float totalProfits = 0;
    public Text profitText;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        profitText.text = (Mathf.Round(totalProfits * 100f)/100f).ToString("");
    }

    public void addToProfits(float addMoney)
    {
        this.totalProfits = this.totalProfits + addMoney;
    }
    public void addToProfits(int addMoney)
    {
        this.totalProfits = this.totalProfits + (float)addMoney;
    }
    
    public void addTipToProfits()
    {
        int tip = Random.Range(0, 6); //this will generate a 0-5$ tip
        this.totalProfits = this.totalProfits + (float)tip;
    }

    public float getTotalProfit()
    {
        return this.totalProfits;
    }
    public void setTotalProfit(float LoadedTotal)
    {
        //this.totalProfits =LoadedTotal;
        addToProfits(LoadedTotal);
        Debug.Log("UpdateTotal to: " +LoadedTotal);
    }
}
