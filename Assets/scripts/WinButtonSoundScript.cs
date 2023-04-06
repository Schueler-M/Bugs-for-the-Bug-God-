using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinButtonSoundScript : MonoBehaviour
{
    AudioSource WinButtonAudio;

    void Start()
    {
        WinButtonAudio = GetComponent<AudioSource>();
        DontDestroyOnLoad(transform.gameObject);
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name != "Win_Screen")
        {
            if (!WinButtonAudio.isPlaying)
            {
                Destroy(gameObject);
            }
        }
    }
}
