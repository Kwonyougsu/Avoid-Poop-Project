using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class BGMsound : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider audioSlider;

    public void AudioControl()
    {
        float sound = audioSlider.value;

        if (sound == -40f)
           audioMixer.SetFloat("BGM", -80f);
        else 
            audioMixer.SetFloat("BGM", sound);
        
    }
}
