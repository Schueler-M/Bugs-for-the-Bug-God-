using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugsToDropdown : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        dataManager data = GameObject.Find("DataManager").GetComponent<dataManager>();
        data.addBugsToDropDown();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
