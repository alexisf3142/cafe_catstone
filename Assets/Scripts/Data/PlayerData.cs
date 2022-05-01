using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData 
{
    public string cafeName;
    public double money;
    public int level;

    public PlayerData(string name, double money, int level){
        this.cafeName = name;
        this.money = money;
        this.level = level;
    }

    public void updateTotal(double money)
    {
        this.money = money;
    }

    public override string ToString()
    {
        return $"{cafeName} cafe is at level {level} with ${money} ";
    }
}
