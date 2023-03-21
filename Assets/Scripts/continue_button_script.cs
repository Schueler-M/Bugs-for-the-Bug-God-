using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class continue_button_script : MonoBehaviour
{
    public void Continue(){
        SceneManager.LoadScene("put_shop_scene_name_here");
        //Debug.Log("Player Hit Continue");     //just for testing
    }
}
