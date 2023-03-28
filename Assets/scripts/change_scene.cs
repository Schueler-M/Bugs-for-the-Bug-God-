using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class change_scene : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ant_prefab;
    public GameObject spider_prefab;
    public GameObject beetle_prefab;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadSceneNum(int num)
    {
        SceneManager.LoadScene(num);
    }
    public void LoadThisScene()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadSceneString(string s)
    {
        SceneManager.LoadScene(s);
    }

    public void wrapper()
    {
        StartCoroutine(GoToFight());
    }
    IEnumerator GoToFight()
    {
        List<int> values = new List<int>();
        GameObject dropobjA = GameObject.Find("Dropdown");
        TMP_Dropdown dropOptA = dropobjA.GetComponent<TMP_Dropdown>();
        print(dropobjA);
        values.Add(dropOptA.value);

        GameObject dropobjB = GameObject.Find("DropdownB");
        TMP_Dropdown dropOptB = dropobjB.GetComponent<TMP_Dropdown>();
        values.Add(dropOptB.value);

        GameObject dropobjC = GameObject.Find("DropdownC");
        TMP_Dropdown dropOptC = dropobjC.GetComponent<TMP_Dropdown>();
        values.Add(dropOptC.value);
        int indexA = 0;
        foreach (int i in values)
        {
            if (i != 0)
            {
                int indexB = 0;
                foreach (int j in values)
                {
                    if (i == j && indexA != indexB)
                    {
                        print("You chose the same bug twice!");
                        yield break;
                    }
                    indexB++;
                }
            }
            if (i == 0)//i == 0 && indexA == 0
            {
                print("You need a to fill all bugs!");
                yield break;
            }
            indexA++;
        }
        DontDestroyOnLoad(this.gameObject);
        SceneManager.LoadScene("Arena");
        // var op = SceneManager.LoadSceneAsync("NavTestNavmesh");
        //need coroutine
        yield return null;
        print("Continuing");
        GameObject player = GameObject.Find("Player");
        print(player);
        Player ps = player.GetComponent<Player>();
        dataManager data = GameObject.Find("DataManager").GetComponent<dataManager>();
        List<Player> list = new List<Player>();
        for (int i = 0; i < values.Count; i++)
        {
            /*
            GameObject new_inst;
            if (values[i] == 0)
            {
                new_inst = GameObject.Instantiate(ant_prefab, player.transform);
            }
            else if (values[i] == 1)
            {
                new_inst = GameObject.Instantiate(spider_prefab, player.transform);
            }
            else
            {
                new_inst = GameObject.Instantiate(beetle_prefab, player.transform);
            }
            ps.playerBugs[i] = new_inst.GetComponent<Player>();*/
            GameObject curBug = data.bugList[values[i] - 1];
            curBug.transform.position = player.transform.position;
            curBug.transform.parent = player.transform;
            ps.playerBugs[i] = curBug.GetComponent<Player>();
        }
        ps.playerBugs[0].gameObject.SetActive(true);
        ps.playerBugs[1].gameObject.SetActive(false);
        ps.playerBugs[2].gameObject.SetActive(false);
        Destroy(transform.gameObject);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
