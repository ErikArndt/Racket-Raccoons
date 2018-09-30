using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Sound : MonoBehaviour
{
    AudioSource m_MyAudioSource;

    void Start()
    {
        Button my_Button = GetComponent<Button>();
        m_MyAudioSource = GetComponent<AudioSource>();
        Debug.Log("declared");

        my_Button.onClick.AddListener(PlayMusic);
    }

    void PlayMusic()
    {
        Debug.Log("playing");
        m_MyAudioSource.Play();
    }


    void Update()
    {


    }

}

