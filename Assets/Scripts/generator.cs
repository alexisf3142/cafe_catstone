using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generator 
{
    
    string[] CoffeeList = { "Hot Coffee", "Cold Coffee", "Latte"};    
    string[] BakeryListItem = { "Doughnut", "Muffin"};    
    
    public List<string> genrateOrder(){
        List<string> currOrder = new List<string>();
        currOrder.Add(genrateCoffee());
        currOrder.Add( genrateBakeryItem());

        return currOrder;
    }

    /* What do: This function chooses a random coffee from the CoffeeList
     * Input: Nothing
     * Output: a random type of coffee
     */
    private string genrateCoffee()
    {
        string chosenCoffee = CoffeeList[Random.Range(0,3)];
        return chosenCoffee;
    }
    
    /* What do: This function chooses a random Bakery Item from the BakeryListItem list
     * Input: Nothing
     * Output: a random type of Bakery Item
     */
    private string genrateBakeryItem()
    {
        string chosenBakeryItem = BakeryListItem[Random.Range(0,2)];;
        return chosenBakeryItem;
    }

    public bool returnRandomBool()
    {
        if (Random.Range(0,2) == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

}
