using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BugsToDropdown : MonoBehaviour
{
    // Start is called before the first frame update
    public bool moreThenOne = true;
    public bool onUpgradeMenu = false;
    TMP_Dropdown dropOpt;
    GameObject bugStats;
    void Start()
    {
        dataManager data = GameObject.Find("DataManager").GetComponent<dataManager>();
        if(moreThenOne)
            data.addBugsToDropDown();
        else
            data.addBugsToADropDown();
        if(onUpgradeMenu)
        {
            bugStats = transform.Find("BugSelected").gameObject;
            dropOpt = GameObject.Find("Dropdown").GetComponent<TMP_Dropdown>();
            bugStats.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (onUpgradeMenu)
        {
            if(dropOpt.value != 0)
            {
                bugStats.SetActive(true);
            }
            else
            {
                bugStats.SetActive(false);
            }
        }
    }

    
}
