using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InvDropdown : MonoBehaviour
{
    // Start is called before the first frame update
    TMP_Dropdown dropOpt;
    dataManager data;
    float refresh = 0.5f;
    void Start()
    {
        data = GameObject.Find("DataManager").GetComponent<dataManager>();
        dropOpt = GetComponent<TMP_Dropdown>();
        List<string> options = new List<string>();
        options.Add("None");
        foreach (var option in data.inv)
        {
            options.Add(option);
        }
        dropOpt.ClearOptions();
        dropOpt.AddOptions(options);
    }

    // Update is called once per frame
    void Update()
    {
           
    }

    public void equipBug()
    {
        TMP_Dropdown dropOptA = GameObject.Find("Dropdown").GetComponent<TMP_Dropdown>();
        GameObject curBug = data.bugList[dropOpt.value - 1];
        Player bs = curBug.GetComponent<Player>();
        bs.weapon = data.inv[dropOpt.value];
    }

    public void refreshAltInv()
    {
        List<string> options = new List<string>();
        options.Add("None");
        foreach (var option in data.inv)
        {
            options.Add(option);
        }
        dropOpt.ClearOptions();
        dropOpt.AddOptions(options);
    }

}
