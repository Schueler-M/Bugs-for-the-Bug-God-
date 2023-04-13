using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class dataManager : MonoBehaviour
{
    public static dataManager Instance;

    public List<GameObject> bugList;
    public int gold = 200;
    public int goldWin = 0;
    public List<string> inv;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void addBugsToDropDown()
    {
        TMP_Dropdown dropOptA;
        TMP_Dropdown dropOptB;
        TMP_Dropdown dropOptC;
        try
        {

            GameObject dropobjA = GameObject.Find("Dropdown");
            dropOptA = dropobjA.GetComponent<TMP_Dropdown>();

            GameObject dropobjB = GameObject.Find("DropdownB");
            dropOptB = dropobjB.GetComponent<TMP_Dropdown>();

            GameObject dropobjC = GameObject.Find("DropdownC");
            dropOptC = dropobjC.GetComponent<TMP_Dropdown>();

        }
        finally { }

        List<string> options = new List<string>();
        options.Add("None");
        foreach (var option in bugList)
        {
            options.Add(option.GetComponent<Player>().name);
        }
        try
        {
            dropOptA.ClearOptions();
            dropOptB.ClearOptions();
            dropOptC.ClearOptions();
            dropOptA.AddOptions(options);
            dropOptB.AddOptions(options);
            dropOptC.AddOptions(options);
        }
        finally { }
    }
    public void addBugsToADropDown()
    {
        TMP_Dropdown dropOptA;
        GameObject dropobjA = GameObject.Find("Dropdown");
        dropOptA = dropobjA.GetComponent<TMP_Dropdown>();

        List<string> options = new List<string>();
        options.Add("None");
        foreach (var option in bugList)
        {
            options.Add(option.GetComponent<Player>().name);
        }
        dropOptA.ClearOptions();
        dropOptA.AddOptions(options);
    }

}