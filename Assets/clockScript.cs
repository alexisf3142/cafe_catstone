using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clockScript : MonoBehaviour
{
    private int starigHour = 7;
    private int starigMin = 0;
    private static int amountOfMinOpen = 480;
    private int amountOfTimeLeft = 480;

    private int minIntervals = 0;
    
    public Text clockText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        updateClockText();
    }


    public void setClockCustomerCount(int numOfCustomers)
    {
        minIntervals = amountOfMinOpen / numOfCustomers;
    }
    
    public void UpdateClock()
    {
        amountOfTimeLeft = amountOfTimeLeft - minIntervals;
        //add time interval to clock
        // if (amountOfTimeLeft < minIntervals*2)
        // {
        //     //add what is left
        //     int newTimeInterval = amountOfTimeLeft;
        //     addMinsToClock(newTimeInterval);
        //
        // }
        // else
        // {
        //     addMinsToClock(minIntervals);
        // }
        addMinsToClock(minIntervals);

    }

    private void addMinsToClock(int min)
    {
        int currMinToAdd = min + starigMin;
        int currHour = starigHour + (currMinToAdd / 60);
        starigHour = currHour % 12;
        starigMin = (currMinToAdd % 60);
        
    }

    private void updateClockText()
    {
        string createdTimeString = "";
        if (starigHour < 1)
        {
            createdTimeString = "12";
        } else if (starigHour < 10)
        {
            createdTimeString = "0" + starigHour.ToString();
        }
        else
        {
            createdTimeString = starigHour.ToString();
        }

        createdTimeString = createdTimeString + ":";
        
        if (starigMin < 10)
        {
            createdTimeString = createdTimeString+"0" + starigMin.ToString();
        }
        else
        {
            createdTimeString = createdTimeString+starigMin.ToString();
        }
        clockText.text = createdTimeString;
    }

}
