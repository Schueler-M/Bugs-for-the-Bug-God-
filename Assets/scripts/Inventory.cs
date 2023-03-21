using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory
{
    public string[] inventory;
    public string[] bugs;
    public int gold;
    
    public Inventory() { }

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
}