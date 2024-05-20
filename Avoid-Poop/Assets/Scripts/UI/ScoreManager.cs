using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TMP_Text currentScoreTxt;
    [SerializeField] TMP_Text highScoreText;

    [SerializeField] TMP_Text nowScoreTxt;
    [SerializeField] TMP_Text HighScoreText;

    public static ScoreManager Instance;
    public GameObject endPanel;

    private float score;
    private float bestScore = 0;
    private string key = "BestScore";

    private void Awake()
    {
        bestScore = PlayerPrefs.GetFloat(key, 0);
        highScoreText.text = $"HIGH : {bestScore.ToString("N2")}";

        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        score = 0;
        Time.timeScale = 1.0f; 
    }

    void Update()
    {
        Score();
    }

    public void Score()
    {
        //time.time은 잘 안씀 재로딩의 경우 
        score += Time.deltaTime;
        currentScoreTxt.text = $"Score : {score.ToString("N2")}";

        if (score > bestScore)
        {
            PlayerPrefs.SetFloat(key, score);
        }
    }
    public void GameOver()
    {
        nowScoreTxt.text = $"{score.ToString("N2")}";
        HighScoreText.text = $"{bestScore.ToString("N2")}";
        endPanel.SetActive(true);
    }
}
