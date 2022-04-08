using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generator 
{
    public List<string> genrateOrder(){
        List<string> currOrder = new List<string>();
        currOrder.Add("Coffee");
        currOrder.Add("Donut");

        return currOrder;
    }

    private string genrateCoffee()
    {
        string chosenCoffe = "none";

        return chosenCoffe;
    }
    
    private string genrateDonut()
    {
        string chosenDonut = "none";

        return chosenDonut;
    }

}
