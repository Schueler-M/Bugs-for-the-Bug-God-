using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSoundTScript : MonoBehaviour
{
    AudioSource TButtonAudio;

    void Start()
    {
        TButtonAudio = GetComponent<AudioSource>();
        DontDestroyOnLoad(transform.gameObject);
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name != "Town")
        {
            if (!TButtonAudio.isPlaying)
            {
                Destroy(gameObject);
            }
        }
    }
}