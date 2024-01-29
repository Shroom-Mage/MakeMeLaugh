using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAllSources : MonoBehaviour
{
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
