using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonFunction : MonoBehaviour
{
    public GameObject SoundSetting;


    public void StartBtn()
    {
        //메인 씬으로 이동 
        SceneManager.LoadScene(0);
    }
    public void Soundsetting()
    {
        SoundSetting.SetActive(true);
    }

    public void AudioOnToggle()
    {
        AudioListener.volume = 1.0f;
    }
    public void AudioOffToggle()
    {
        AudioListener.volume = 0.0f;
    }
}
