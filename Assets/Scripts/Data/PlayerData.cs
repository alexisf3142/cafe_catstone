using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData 
{
    public string name;
    public double money;
    public int level;

    public PlayerData(string name, double money, int level){
        this.name = name;
        this.money = money;
        this.level = level;
    }

    public override string ToString()
    {
        return $"{name} is at level {level} with ${money} ";
    }
}
