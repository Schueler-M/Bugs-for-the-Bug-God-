using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSoundScript : MonoBehaviour
{
    AudioSource TheButtonAudio;

    void Start()
    {
        TheButtonAudio = GetComponent<AudioSource>();
        DontDestroyOnLoad(transform.gameObject);
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name != "MidMenu")
        {
            if (!TheButtonAudio.isPlaying)
            {
                Destroy(gameObject);
            }
        }
    }
}
