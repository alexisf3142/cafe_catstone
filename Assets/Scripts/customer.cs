using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class customer 
{
    private bool orderStatus;
    private int placeInLine; // add this in later
    private List<string> orderList = new List<string>();
    public int orterItemNum;

    public customer(List<string> order) {
        this.orderStatus = false;
        this.placeInLine = 0;
        this.orderList = order;
        this.orterItemNum = orderList.Count;
    }


    /*public void printInfo(){
        Console.WriteLine(orderStatus);
        Console.WriteLine(placeInLine);
        Console.WriteLine(orderList[0] + ' ' + orderList[1]);
        Console.WriteLine(this.orterItemNum);
    }*/

    public bool getOrderStatus (){
        return this.orderStatus;
    }
}
