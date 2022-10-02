using System;
using System.Collections;
using System.Collections.Generic;
using SonicBloom.Koreo;
using UnityEngine;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    [SerializeField] private List<GameObject> toEnable;
    [SerializeField] private Button button;
    [SerializeField] private AudioSource audioSource;

    private bool paused;
    
    private void OnEnable()
    {
        button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        if (paused)
            Resume();
        else
            Pause();
    }

    private void Pause()
    {
        paused = true;

        foreach (var gameObject in toEnable)
        {
            gameObject.SetActive(true);
        }

        Time.timeScale = 0;

        audioSource.pitch = 0;
    }

    private void Resume()
    {
        paused = false;
        
        foreach (var gameObject in toEnable)
        {
            gameObject.SetActive(false);
        }

        Time.timeScale = 1;

        audioSource.pitch = 1;
    }
}
