using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class BugStats : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject BugGen;
    BugGenerator BugGenScript;
    GameObject dropobj;
    TMP_Dropdown dropOpt;
    GameObject curBug;
    public int BugI;
    TextMeshProUGUI type;
    TextMeshProUGUI name;
    TextMeshProUGUI hp;
    TextMeshProUGUI speed;
    TextMeshProUGUI atk;
    TextMeshProUGUI def;
    TextMeshProUGUI up;
    dataManager data;
    float timer = 0.3f;
    void Start()
    {
        BugGen = GameObject.Find("GenBugs");
        //BugGenScript = BugGen.GetComponent<BugGenerator>();
        data = GameObject.Find("DataManager").GetComponent<dataManager>();
        name = transform.Find("Name").GetComponent<TextMeshProUGUI>();
        hp = transform.Find("HP").GetComponent<TextMeshProUGUI>();
        speed = transform.Find("Speed").GetComponent<TextMeshProUGUI>();
        atk = transform.Find("Atk").GetComponent<TextMeshProUGUI>();
        def = transform.Find("Def").GetComponent<TextMeshProUGUI>();
        up = transform.Find("Upgrade").GetComponent<TextMeshProUGUI>();
        type = GetComponent<TextMeshProUGUI>();
        print(type);
        print(name);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            timer = 0.3f;
            if (BugI == 0)
                dropobj = GameObject.Find("Dropdown");
            else if (BugI == 1)
                dropobj = GameObject.Find("DropdownB");
            else
                dropobj = GameObject.Find("DropdownC");
            dropOpt = dropobj.GetComponent<TMP_Dropdown>();
            try
            {
                curBug = data.bugList[dropOpt.value - 1];
                ant antScript = curBug.GetComponent<ant>();
                spider spiderScript = curBug.GetComponent<spider>();
                beetle beetleScript = curBug.GetComponent<beetle>();
                if (antScript != null)
                {
                    type.text = "Bug" + (BugI + 1).ToString() + ": Ant";
                    name.text = "Name: " + antScript.name;
                    hp.text = "HP: " + antScript.curhp;
                    speed.text = "Speed: " + antScript.curSpeed;
                    atk.text = "Atk: " + antScript.curAtk;
                    def.text = "Def: " + antScript.curDef;
                    try { up.text = "Upgrade Points: " + antScript.upgradePoints.ToString(); }
                    finally { }
                }
                else if (spiderScript != null)
                {
                    type.text = "Bug" + (BugI + 1).ToString() + ": Spider";
                    name.text = "Name: " + spiderScript.name;
                    hp.text = "HP: " + spiderScript.curhp;
                    speed.text = "Speed: " + spiderScript.curSpeed;
                    atk.text = "Atk: " + spiderScript.curAtk;
                    def.text = "Def: " + spiderScript.curDef;
                    try { up.text = "Upgrade Points: " + spiderScript.upgradePoints.ToString(); }
                    finally { }
                }
                else if (beetleScript != null)
                {
                    type.text = "Bug" + (BugI + 1).ToString() + ": Beetle";
                    name.text = "Name: " + beetleScript.name;
                    hp.text = "HP: " + beetleScript.curhp;
                    speed.text = "Speed: " + beetleScript.curSpeed;
                    atk.text = "Atk: " + beetleScript.curAtk;
                    def.text = "Def: " + beetleScript.curDef;
                    try { up.text = "Upgrade Points: " + beetleScript.upgradePoints.ToString(); }
                    finally { }
                }
            }
            catch (Exception ex)
            {
                type.text = "Bug" + (BugI + 1).ToString() + ":";
                name.text = "Name: ";
                hp.text = "HP: ";
                speed.text = "Speed: ";
                atk.text = "Atk: ";
                def.text = "Def: ";
                //Debug.LogException(ex, this);
            }

            //type.text = curBug.
        }
    }

    public void upgradeHP()
    {
        curBug = data.bugList[dropOpt.value - 1];
        ant antScript = curBug.GetComponent<ant>();
        spider spiderScript = curBug.GetComponent<spider>();
        beetle beetleScript = curBug.GetComponent<beetle>();
        if (antScript != null)
        {
            if(antScript.upgradePoints > 0)
            {
                antScript.upgradePoints -= 1;
                antScript.curhp += 100;
                antScript.resetStats();
            }
        }
        else if (spiderScript != null)
        {
            if (spiderScript.upgradePoints > 0)
            {
                spiderScript.upgradePoints -= 1;
                spiderScript.curhp += 100;
                spiderScript.resetStats();
            }
        }
        else if (beetleScript != null)
        {
            if (beetleScript.upgradePoints > 0)
            {
                beetleScript.upgradePoints -= 1;
                beetleScript.curhp += 100;
                beetleScript.resetStats();
            }
        }
    }

    public void upgradeSpeed()
    {
        curBug = data.bugList[dropOpt.value - 1];
        ant antScript = curBug.GetComponent<ant>();
        spider spiderScript = curBug.GetComponent<spider>();
        beetle beetleScript = curBug.GetComponent<beetle>();
        if (antScript != null)
        {
            if (antScript.upgradePoints > 0)
            {
                antScript.upgradePoints -= 1;
                antScript.curSpeed += 1;
                antScript.resetStats();
            }
        }
        else if (spiderScript != null)
        {
            if (spiderScript.upgradePoints > 0)
            {
                spiderScript.upgradePoints -= 1;
                spiderScript.curSpeed += 1;
                spiderScript.resetStats();
            }
        }
        else if (beetleScript != null)
        {
            if (beetleScript.upgradePoints > 0)
            {
                beetleScript.upgradePoints -= 1;
                beetleScript.curSpeed += 1;
                beetleScript.resetStats();
            }
        }
    }

    public void upgradeAtk()
    {
        curBug = data.bugList[dropOpt.value - 1];
        ant antScript = curBug.GetComponent<ant>();
        spider spiderScript = curBug.GetComponent<spider>();
        beetle beetleScript = curBug.GetComponent<beetle>();
        if (antScript != null)
        {
            if (antScript.upgradePoints > 0)
            {
                antScript.upgradePoints -= 1;
                antScript.curAtk += 10;
                antScript.resetStats();
            }
        }
        else if (spiderScript != null)
        {
            if (spiderScript.upgradePoints > 0)
            {
                spiderScript.upgradePoints -= 1;
                spiderScript.curAtk += 10;
                spiderScript.resetStats();
            }
        }
        else if (beetleScript != null)
        {
            if (beetleScript.upgradePoints > 0)
            {
                beetleScript.upgradePoints -= 1;
                beetleScript.curAtk += 10;
                beetleScript.resetStats();
            }
        }
    }
    public void upgradeDef()
    {
        curBug = data.bugList[dropOpt.value - 1];
        ant antScript = curBug.GetComponent<ant>();
        spider spiderScript = curBug.GetComponent<spider>();
        beetle beetleScript = curBug.GetComponent<beetle>();
        if (antScript != null)
        {
            if (antScript.upgradePoints > 0)
            {
                antScript.upgradePoints -= 1;
                antScript.curDef += 10;
                antScript.resetStats();
            }
        }
        else if (spiderScript != null)
        {
            if (spiderScript.upgradePoints > 0)
            {
                spiderScript.upgradePoints -= 1;
                spiderScript.curDef += 10;
                spiderScript.resetStats();
            }
        }
        else if (beetleScript != null)
        {
            if (beetleScript.upgradePoints > 0)
            {
                beetleScript.upgradePoints -= 1;
                beetleScript.curDef += 10;
                beetleScript.resetStats();
            }
        }
    }

}
