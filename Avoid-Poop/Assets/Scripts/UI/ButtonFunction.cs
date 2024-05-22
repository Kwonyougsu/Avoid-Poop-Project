using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonFunction : MonoBehaviour
{
    public GameObject diffSelecet;
    public GameObject SoundSetting;
    public GameObject RankingPanel;
    public GameObject StopPanel;
    public GameObject CharacterSetting;

    public void RankingBtn()
    {
        RankingPanel.SetActive(true);
        CharacterSetting.SetActive(false);
    }
    public void CloseRankingPanel()
    {
        RankingPanel.SetActive(false);
        CharacterSetting.SetActive(true);
    }
    public void Soundsetting()
    {
        SoundSetting.SetActive(true);
        CharacterSetting.SetActive(false);
    }
    public void CloseSoundsetting()
    {
        SoundSetting.SetActive(false);
        CharacterSetting.SetActive(true);
    }
    public void Selectdiff()
    {
        diffSelecet.SetActive(true);
        CharacterSetting.SetActive(false);
    }
    public void CloseSelectdiff()
    {
        diffSelecet.SetActive(false);
        CharacterSetting.SetActive(true);
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

    public void Pasue()
    {
        StopPanel.SetActive(true);
        Time.timeScale=0f;
    }

    public void ClosePasue()
    {
        StopPanel.SetActive(false);
        Time.timeScale=1f;
    }
    public void GameEndButtom()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif

    }
}
