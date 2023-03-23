using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class main_menu_script : MonoBehaviour
{
    void Update(){
        if(Time.time > 0.45)
            //turns the animator off when the buttons reach desired location on screen
            gameObject.GetComponent<Animator>().enabled = false;
    }

    public void Play(){
        //put the shop or intended next scene in build order or use
        //the commented line with the appropriate scene name instead
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //SceneManager.LoadScene(put_shop_scene_name_here);
        //Debug.Log("Player Hit Play");     //just for testing
    }

    public void Options(){
        //Debug.Log("You can customize any option as long as it's the default");        //just for testing
    }

    public void Quit(){
        Application.Quit();
        //Debug.Log("Player Has Quit The Game");        //just for testing
    }
}
