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
        //���� ������ �̵� 
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
        //���� ����
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

    public void Retry()
    {
        //���� �ٽ��ϱ�
        SceneManager.LoadScene(1);
    }
    public void back()
    {
        //�κ�� �̵��ϱ�
        SceneManager.LoadScene(0);

    }
}
