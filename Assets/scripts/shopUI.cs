using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class shopUI : MonoBehaviour
{
    TextMeshProUGUI gold;
    dataManager data;
    void Start()
    {
        data = GameObject.Find("DataManager").GetComponent<dataManager>();
        gold = transform.Find("gold_icon").transform.Find("current_gold").GetComponent<TextMeshProUGUI>();
        gold.text = "Gold: " + data.gold.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        gold.text = "Gold: " + data.gold.ToString();
    }

}
