using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData 
{
    public string cafeName;
    public double money;
    public int day;
    public int coffeeServed;

    public PlayerData(string name, double money, int day, int coffeeServed){
        this.cafeName = name;
        this.money = money;
        this.day = day;
        this.coffeeServed = coffeeServed;
    }

    public void updateTotal(double money)
    {
        this.money = money;
    }
    
    public void updateDay(int day)
    {
        this.day = day;
    }
    
    public void updateCoffeeServed(int coffeeServed)
    {
        this.coffeeServed = coffeeServed;
    }

    public override string ToString()
    {
        return $"{cafeName} cafe is at day {day} with ${money} with {coffeeServed} coffees served";
    }
}
