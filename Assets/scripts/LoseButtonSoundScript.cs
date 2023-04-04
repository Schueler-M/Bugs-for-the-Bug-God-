using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseButtonSoundScript : MonoBehaviour
{
    AudioSource LoseButtonAudio;

    void Start()
    {
        LoseButtonAudio = GetComponent<AudioSource>();
        DontDestroyOnLoad(transform.gameObject);
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name != "Lose_Screen")
        {
            if (!LoseButtonAudio.isPlaying)
            {
                Destroy(gameObject);
            }
        }
    }
}
