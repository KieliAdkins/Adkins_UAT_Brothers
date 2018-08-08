using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class VolumeController : MonoBehaviour {

    // Defining our variables
    public Slider volumeSlider;
    public AudioSource volumeAudio;

    // Volume Vontroller function
    public void VController()
    {
        volumeSlider.value = volumeAudio.volume;
    }
}
