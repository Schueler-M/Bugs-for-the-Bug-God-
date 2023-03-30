using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugsToDropdown : MonoBehaviour
{
    // Start is called before the first frame update
    public bool moreThenOne = true;
    void Start()
    {
        dataManager data = GameObject.Find("DataManager").GetComponent<dataManager>();
        if(moreThenOne)
            data.addBugsToDropDown();
        else
            data.addBugsToADropDown();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
