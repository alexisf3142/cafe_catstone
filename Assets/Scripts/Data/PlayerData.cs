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

    public override string ToString()
    {
        return $"{cafeName} cafe is at day {day} with ${money} with ${coffeeServed}";
    }
}
