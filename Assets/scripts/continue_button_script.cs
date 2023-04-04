using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class continue_button_script : MonoBehaviour
{
    public void Continue(){
        SceneManager.LoadScene("Town");
        //Debug.Log("Player Hit Continue");     //just for testing
    }
}
