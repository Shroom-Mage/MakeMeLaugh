using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAllSources : MonoBehaviour
{
    [SerializeField]
    public bool stopOnStart = false;

    void Start()
    {
        if(stopOnStart)
        {
            StopAllAudioSources();
        }
    }

    public void StopAllAudioSources()
    {
        // Find all AudioSources in the scene
        AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();

        // Stop each AudioSource
        foreach (AudioSource audioSource in allAudioSources)
        {
            audioSource.Stop();
        }
    }
}
