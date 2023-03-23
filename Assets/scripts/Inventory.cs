using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory
{
    public string[] inventory = new string[9];
    public string[] bugs = new string[3];
    public int gold = 0;
    
    public Inventory() {
        
    }

    public Inventory(string[] inv, string[] newBugs, int newGold) 
    {
        inventory = inv;
        bugs = newBugs;
        gold = newGold;
    }

    public void setInv(string[] inv)
    {
        inventory = inv;
    }

    public void setBugs(string[] newBugs)
    {
        bugs = newBugs;
    }

    public void setGold(int newGold)
    {
        gold = newGold;
    }

    public string Save()
    {
        return SaveLoad.SaveData(this);
    }
    public void Load()
    {
        Inventory temp = SaveLoad.LoadData();
        inventory = temp.inventory;
        bugs = temp.bugs;
        gold = temp.gold;
    }
}