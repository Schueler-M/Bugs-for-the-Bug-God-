using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SavingLoading : MonoBehaviour
{

    public TMP_Text textObj;
    public TMP_InputField inputField;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void resetOptions()
    {
        PlayerPrefs.DeleteAll();
    }

    void saveOptions()
    {
        PlayerPrefs.Save();
    }

    public void continueButton()
    {
        textObj.text = inputField.text;
    }

    public void optionsButton()
    {
        string[] temp = { inputField.text };
        SaveLoad.SaveData(new Inventory(temp, null, 10));
    }

    public void quitButton()
    {
        Inventory test = SaveLoad.LoadData();
        Debug.Log(test.inventory.Length);
        textObj.text = test.inventory[0];
        Debug.Log(test.inventory[0]);
    }
}
