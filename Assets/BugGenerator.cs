using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BugGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ant_prefab;
    public GameObject spider_prefab;
    public GameObject beetle_prefab;
    public ant antScript;
    public spider spiderScript;
    public beetle beetleScript;
    string[] antNames = {"Antony", "Antie", "Anth", "Mr.Ant", "Ms.Ant" };
    string[] spiderNames = { "SpiderNotMan", "Spidey", "Spi","Mr.Spider", "Ms.Spider"};
    string[] beetleNames = { "Mr.BeatIt", "Mr.Beat", "Beatrice", "Mr.Beetle", "Ms.Beetle", "Ms.BeatIt", "Ms.Beat"};
    public Player[] bugList;
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
        for (int i = 0; i < numBugsToGenerate; i++)
        {
            int rand = Random.Range(0, 3);
            GameObject new_inst;
            if (rand == 0)
            {
                new_inst = GameObject.Instantiate(ant_prefab);
                antScript = new_inst.GetComponent<ant>();
                antScript.name = antNames[Random.Range(0,antNames.Length)];
                antScript.speed += Random.Range(-2, 2);
                antScript.hp += Random.Range(-50, 50);
                antScript.atk += Random.Range(-10, 10);
                antScript.def += Random.Range(-10, 10);
            }
            else if (rand == 1)
            {
                new_inst = GameObject.Instantiate(spider_prefab);
                spiderScript = new_inst.GetComponent<spider>();
                spiderScript.name = spiderNames[rand = Random.Range(0, spiderNames.Length)];
                spiderScript.speed += Random.Range(-2, 2);
                spiderScript.hp += Random.Range(-50, 50);
                spiderScript.atk += Random.Range(-10, 10);
                spiderScript.def += Random.Range(-10, 10);
            }
            else
            {
                new_inst = GameObject.Instantiate(beetle_prefab);
                beetleScript = new_inst.GetComponent<beetle>();
                beetleScript.name = beetleNames[rand = Random.Range(0, beetleNames.Length)];
                beetleScript = new_inst.GetComponent<beetle>();
                beetleScript.name = spiderNames[rand = Random.Range(0, spiderNames.Length)];
                beetleScript.speed += Random.Range(-2, 2);
                beetleScript.hp += Random.Range(-50, 50);
                beetleScript.atk += Random.Range(-10, 10);
                beetleScript.def += Random.Range(-10, 10);
            }
            //add to buglist
        }

    }
}
