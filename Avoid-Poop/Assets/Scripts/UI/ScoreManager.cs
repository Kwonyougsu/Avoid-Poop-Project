using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TMP_Text currentScoreTxt;
    [SerializeField] TMP_Text highScoreText;
    
    private float bestScore = 0f;
    public float currentScore;

    [SerializeField] TMP_Text nowScoreTxt;
    [SerializeField] TMP_Text HighScoreText;

    public static ScoreManager Instance;
    public GameObject endPanel;
    public GameObject PasuePanel;


    private void Awake()
    {
        bestScore = PlayerPrefs.GetFloat("BestScore", 0);
        highScoreText.text = $"HIGH : {bestScore.ToString("N2")}"; 

        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        currentScore = 0;
        Time.timeScale = 1.0f; 
    }

    void Update()
    {
        Score();
    }

    public void Score()
    {
        // time.time은 되도록 사용하지 않고 Time.deltaTime 로 사용한다 
        currentScore += Time.deltaTime;
        currentScoreTxt.text = $"Score : {currentScore.ToString("N2")}";

        if (currentScore > bestScore)
        {
            PlayerPrefs.SetFloat("BestScore", currentScore);
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0f; 
        nowScoreTxt.text = $"{currentScore.ToString("N2")}";
        HighScoreText.text = $"{bestScore.ToString("N2")}";
        endPanel.SetActive(true);
        PasuePanel.SetActive(false);
    }
}
