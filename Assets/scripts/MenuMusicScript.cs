using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMusicScript : MonoBehaviour
{
    public static MenuMusicScript instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnLevelWasLoaded(int level)
    {
        if (SceneManager.GetActiveScene().name == "MidMenu")
        {
            instance.GetComponent<AudioSource>().Pause();
            instance.GetComponent<AudioSource>().Play();
        }
        else if (SceneManager.GetActiveScene().name == "FightMenu")
        {
            instance.GetComponent<AudioSource>().Pause();
            instance.GetComponent<AudioSource>().Play();
        }
        else
        {
            instance.GetComponent<AudioSource>().Pause();
        }
    }
}
