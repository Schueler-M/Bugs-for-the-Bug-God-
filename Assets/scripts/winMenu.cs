using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class winMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        dataManager data = GameObject.Find("DataManager").GetComponent<dataManager>();
        TextMeshProUGUI gotGold = transform.Find("Gold").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI totalGold = transform.Find("GoldTotal").GetComponent<TextMeshProUGUI>();
        int goldGot = Random.Range(1000, 5000);
        data.gold += goldGot;
        gotGold.text = "Gold Obtained: " + goldGot.ToString();
        totalGold.text = "Gold: " + data.gold.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
