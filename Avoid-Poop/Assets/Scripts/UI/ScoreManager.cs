using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TMP_Text currentScoreTxt;
    [SerializeField] TMP_Text highScoreText;

    private float score = 0;
    private float bestScore = 0;
    private string key = "BestScore";

    private void Awake()
    {
        bestScore = PlayerPrefs.GetFloat(key, 0);
        highScoreText.text = $"HIGH : {bestScore.ToString("N2")}";
    }

    void Start()
    {
        Time.timeScale = 1f; 
    }

    void Update()
    {
        Score();
    }

    public void Score()
    {
        score = Time.time;
        currentScoreTxt.text = $"Score : {score.ToString("N2")}";

        if (score > bestScore)
        {
            PlayerPrefs.SetFloat(key, score);
        }
    }
}
