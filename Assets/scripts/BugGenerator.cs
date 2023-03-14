using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;


public class BugGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ant_prefab;
    public GameObject spider_prefab;
    public GameObject beetle_prefab;
    ant antScript;
    spider spiderScript;
    beetle beetleScript;
    string[] antNames = {"Antony", "Antie", "Anth", "Mr.Ant", "Ms.Ant", "Anton", "Antea", "Antario", "Antara", "Antanette", "Antaun" };
    string[] spiderNames = { "SpiderNotMan", "Spidey", "Spi","Mr.Spider", "Ms.Spider","Webber", "Peter", "Parker","Webster", "Spike","Silky","Fang","Venom","Itsy","Bitsy" ,"Betty","Tiny","Smalls","Squirt","Sticky","Spins"};
    string[] beetleNames = { "Mr.BeatIt", "Mr.Beat", "Beatrice", "Mr.Beetle", "Ms.Beetle", "Ms.BeatIt", "Ms.Beat", "Heracro", "Batal", "Bethley"};
    public List<GameObject> bugList;
    public int numBugsToGenerate = 3;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void generateBugs()
    {
        GameObject dropobjA = GameObject.Find("Dropdown");
        TMP_Dropdown dropOptA = dropobjA.GetComponent<TMP_Dropdown>();

        GameObject dropobjB = GameObject.Find("DropdownB");
        TMP_Dropdown dropOptB = dropobjB.GetComponent<TMP_Dropdown>();

        GameObject dropobjC = GameObject.Find("DropdownC");
        TMP_Dropdown dropOptC = dropobjC.GetComponent<TMP_Dropdown>();
        for (int i = 0; i < numBugsToGenerate; i++)
        {
            int rand = Random.Range(0, 3);
            GameObject new_inst;
            if (rand == 0)
            {
                new_inst = GameObject.Instantiate(ant_prefab,transform);
                antScript = new_inst.GetComponent<ant>();
                antScript.name = antNames[Random.Range(0,antNames.Length)];
                antScript.curSpeed += Random.Range(-2, 2);
                antScript.curhp += Random.Range(-50, 50);
                antScript.curAtk += Random.Range(-10, 10);
                antScript.curDef += Random.Range(-10, 10);
                antScript.startPrice += Random.Range(-100, 100);
            }
            else if (rand == 1)
            {
                new_inst = GameObject.Instantiate(spider_prefab, transform);
                spiderScript = new_inst.GetComponent<spider>();
                spiderScript.name = spiderNames[rand = Random.Range(0, spiderNames.Length)];
                spiderScript.curSpeed += Random.Range(-2, 2);
                spiderScript.curhp += Random.Range(-50, 50);
                spiderScript.curAtk += Random.Range(-10, 10);
                spiderScript.curDef += Random.Range(-10, 10);
                spiderScript.startPrice += Random.Range(-100, 100);
            }
            else
            {
                new_inst = GameObject.Instantiate(beetle_prefab, transform);
                beetleScript = new_inst.GetComponent<beetle>();
                beetleScript.name = beetleNames[rand = Random.Range(0, beetleNames.Length)];
                beetleScript = new_inst.GetComponent<beetle>();
                beetleScript.curSpeed += Random.Range(-2, 2);
                beetleScript.curhp += Random.Range(-50, 50);
                beetleScript.curAtk += Random.Range(-10, 10);
                beetleScript.curDef += Random.Range(-10, 10);
                beetleScript.startPrice += Random.Range(-100, 100);
            }
            new_inst.SetActive(false);
            bugList.Add(new_inst.gameObject);//= new_inst;//add to buglist

        }
        List<string> options = new List<string>();
        options.Add("None");
        foreach (var option in bugList)
        {
            options.Add(option.GetComponent<Player>().name);
        }
        dropOptA.ClearOptions();
        dropOptB.ClearOptions();
        dropOptC.ClearOptions();
        dropOptA.AddOptions(options);
        dropOptB.AddOptions(options);
        dropOptC.AddOptions(options);

    }
}
