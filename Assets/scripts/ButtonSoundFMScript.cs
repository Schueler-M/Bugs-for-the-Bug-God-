using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSoundFMScript : MonoBehaviour
{
    AudioSource FMButtonAudio;
    
    void Start()
    {
        FMButtonAudio = GetComponent<AudioSource>();
        DontDestroyOnLoad(transform.gameObject);
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name != "FightMenu")
        {
            if (!FMButtonAudio.isPlaying)
            {
                Destroy(gameObject);
            }
        }
    }
}
