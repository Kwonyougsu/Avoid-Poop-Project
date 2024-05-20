using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonFunction : MonoBehaviour
{
    public GameObject SoundSetting;
    public GameObject RankingPanel;
    public void StartBtn()
    {
        // 게임화면 이동 
        SceneManager.LoadScene(1);
    }

    public void RankingBtn()
    {
        RankingPanel.SetActive(true);
    }
    public void Soundsetting()
    {
        SoundSetting.SetActive(true);
    }

    public void AudioOnToggle()
    {
        // 사운드 조절
        AudioListener.volume = 1.0f;
    }
    public void AudioOffToggle()
    {
        AudioListener.volume = 0.0f;
    }
    public void Close()
    {
        SoundSetting.SetActive(false);
    }


    public void CloseRankingPanel()
    {
        RankingPanel.SetActive(false);
    }
    public void Retry()
    {
        // 게임 다시하기
        SceneManager.LoadScene(1);
    }
    public void back()
    {
        // 로비로 이동하기
        SceneManager.LoadScene(0);

    }
}
