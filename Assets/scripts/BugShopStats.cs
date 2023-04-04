using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class BugShopStats : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject BugGen;
    BugGenerator BugGenScript;
    GameObject curBug;
    public int BugI;
    TextMeshProUGUI type;
    TextMeshProUGUI name;
    TextMeshProUGUI hp;
    TextMeshProUGUI speed;
    TextMeshProUGUI atk;
    TextMeshProUGUI def;
    TextMeshProUGUI price;
    float timer = 0.3f;
    void Start()
    {
        BugGen = GameObject.Find("GenBugs");
        BugGenScript = BugGen.GetComponent<BugGenerator>();
        name = transform.Find("Name").GetComponent<TextMeshProUGUI>();
        hp = transform.Find("HP").GetComponent<TextMeshProUGUI>();
        speed = transform.Find("Speed").GetComponent<TextMeshProUGUI>();
        atk = transform.Find("Atk").GetComponent<TextMeshProUGUI>();
        def = transform.Find("Def").GetComponent<TextMeshProUGUI>();
        price = transform.Find("Price").GetComponent<TextMeshProUGUI>();
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
            try
            {
                curBug = BugGenScript.bugList[BugI];
                ant antScript = curBug.GetComponent<ant>();
                spider spiderScript = curBug.GetComponent<spider>();
                beetle beetleScript = curBug.GetComponent<beetle>();
                if (antScript != null)
                {
                    type.text = "Bug " + (BugI + 1).ToString() + ": Ant";
                    name.text = "Name: " + antScript.name;
                    hp.text = "HP: " + antScript.curhp;
                    speed.text = "Speed: " + antScript.curSpeed;
                    atk.text = "Atk: " + antScript.curAtk;
                    def.text = "Def: " + antScript.curDef;
                    price.text = "Price: " + antScript.startPrice;
                }
                else if (spiderScript != null)
                {
                    type.text = "Bug " + (BugI + 1).ToString() + ": Spider";
                    name.text = "Name: " + spiderScript.name;
                    hp.text = "HP: " + spiderScript.curhp;
                    speed.text = "Speed: " + spiderScript.curSpeed;
                    atk.text = "Atk: " + spiderScript.curAtk;
                    def.text = "Def: " + spiderScript.curDef;
                    price.text = "Price: " + spiderScript.startPrice;
                }
                else if (beetleScript != null)
                {
                    type.text = "Bug " + (BugI + 1).ToString() + ": Beetle";
                    name.text = "Name: " + beetleScript.name;
                    hp.text = "HP: " + beetleScript.curhp;
                    speed.text = "Speed: " + beetleScript.curSpeed;
                    atk.text = "Atk: " + beetleScript.curAtk;
                    def.text = "Def: " + beetleScript.curDef;
                    price.text = "Price: " + beetleScript.startPrice;
                }
            }
            catch (Exception ex)
            {
                type.text = "Bug " + (BugI + 1).ToString() + ":";
                name.text = "Name: ";
                hp.text = "HP: ";
                speed.text = "Speed: ";
                atk.text = "Atk: ";
                def.text = "Def: ";
                price.text = "Price: ";
                //Debug.LogException(ex, this);
            }

            //type.text = curBug.
        }
    }
    public void buyBug()
    {
        curBug = BugGenScript.bugList[BugI];
        ant antScript = curBug.GetComponent<ant>();
        spider spiderScript = curBug.GetComponent<spider>();
        beetle beetleScript = curBug.GetComponent<beetle>();
        dataManager data = GameObject.Find("DataManager").GetComponent<dataManager>();
        if (antScript != null)
        {
            if (antScript.startPrice < data.gold)
            {
                data.bugList.Add(curBug);
                curBug.transform.parent = data.transform;
                data.gold -= antScript.startPrice;
            }
        }
        else if (spiderScript != null)
        {
            if (spiderScript.startPrice < data.gold)
            {
                data.bugList.Add(curBug);
                curBug.transform.parent = data.transform;
                data.gold -= spiderScript.startPrice;
            }
        }
        else if (beetleScript != null)
        {
            if (beetleScript.startPrice < data.gold)
            {
                data.bugList.Add(curBug);
                curBug.transform.parent = data.transform;
                data.gold -= beetleScript.startPrice;
            }
        }
        data.addBugsToADropDown();
    }
}
