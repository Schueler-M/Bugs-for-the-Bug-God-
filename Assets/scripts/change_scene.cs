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
        DontDestroyOnLoad(this.gameObject);
        SceneManager.LoadScene("Arena");
        // var op = SceneManager.LoadSceneAsync("NavTestNavmesh");
        //need coroutine
        yield return null;
        print("Continuing");
        GameObject player = GameObject.Find("Player");
        print(player);
        Player ps = player.GetComponent<Player>();
        List<Player> list = new List<Player>();
        for (int i = 0; i < values.Count; i++)
        {
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
            ps.playerBugs[i] = new_inst.GetComponent<Player>();
        }
        ps.playerBugs[0].gameObject.SetActive(true);
        ps.playerBugs[1].gameObject.SetActive(false);
        ps.playerBugs[2].gameObject.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
