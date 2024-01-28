using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ToggleSound : MonoBehaviour
{
    [SerializeField]
    public bool soundOn = true;

    [SerializeField]
    public Sprite onImage;

    [SerializeField]

    public Sprite offImage;

    [SerializeField]
    public Button imageComp;

    void Start()
    {
        imageComp.image.sprite = soundOn ? onImage : offImage;
        
        UpdateVolume();
    }

    public void toggleSound()
    {
        soundOn = !soundOn;

        // Save the current volume setting to PlayerPrefs
        PlayerPrefs.SetInt("IsVolumeOn", soundOn ? 1 : 0);   

        imageComp.image.sprite = soundOn ? onImage : offImage;
        
    }

    private void UpdateVolume()
    {
        // Toggle the AudioListener component's volume based on the isVolumeOn flag
        AudioListener.volume = soundOn ? 0.5f : 0.0f;
    }

    private void OnMouseDown()
    {
        Console.WriteLine("Sound toggle sound");
        // Toggle the volume when the game object is clicked
        toggleSound();
    }


}
