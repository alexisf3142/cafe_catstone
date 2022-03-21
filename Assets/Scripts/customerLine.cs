using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class customerLine 
{
    private List<customer> theLine;

    public customerLine() {
        this.theLine  = new List<customer>();
    }

    public void addCustomer(customer newCustomer){
        this.theLine.Add(newCustomer);

        //move this customer to the correct postion based on the length of the line 
    }

    private void RemoveFirstCustomerInLine() {
        this.theLine.RemoveAt(0);
    }

    private bool customerOrderCompleted(){
        if (this.theLine[0].getOrderStatus())
        {
            return true; 
        }
        else
        {
            return false;
        }
    }

    public int numOfCustomer(){
        return theLine.Count;
    }

    public void updateLine(){
        if (customerOrderCompleted())
        {
            RemoveFirstCustomerInLine();
        }

        for (int i = 0; i < this.theLine.Count; i++)
        {
            // this.theList[i] <--- update the position (aka move each customerr forward 16 pixels) 
        }
    }
}
