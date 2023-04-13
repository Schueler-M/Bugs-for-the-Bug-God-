using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BugSaveData
{
    public int speed = 1;
    public float hp = 1.0f;
    public int atk = 1;
    public int def = 1;
    public float damageHeal = 0;
    public string name;
    public int price = 0;
    public int upgradePoints = 0;
    public string weapon = "None";

    public float curhp;
    public int curSpeed;
    public int curAtk;
    public int curDef;

}
