using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TMP_Text currentScoreTxt;
    [SerializeField] TMP_Text highScoreText;
    [SerializeField] TMP_Text Ranker1;
    [SerializeField] TMP_Text Ranker2;
    [SerializeField] TMP_Text Ranker3;
    [SerializeField] TMP_Text Ranker4;
    [SerializeField] TMP_Text Ranker5;


    private float[] bestScores = new float[5];
    private string[] bestName = new string[5];
    private float bestScore = 0f;
    private float currentScore = 0;

    private string playerName;

    [SerializeField] TMP_Text nowScoreTxt;
    [SerializeField] TMP_Text HighScoreText;

    public static ScoreManager Instance;
    public GameObject endPanel;

    private void Awake()
    {
        Ranker1.text = $"{bestName[4]} : {bestScores[4]}";
        Ranker2.text = $"{bestName[3]} : {bestScores[3]}";
        Ranker3.text = $"{bestName[2]} : {bestScores[2]}";
        Ranker4.text = $"{bestName[1]} : {bestScores[1]}";
        Ranker5.text = $"{bestName[0]} : {bestScores[0]}";
        bestScore = PlayerPrefs.GetFloat("BestScore", 0);
        highScoreText.text = $"HIGH : {bestScore.ToString("N2")}";

        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        Time.timeScale = 1f; 
    }

    void Update()
    {
        Score();
        RankingSet(currentScore, playerName);
    }

    public void Score()
    {
        currentScore = Time.time;
        currentScoreTxt.text = $"Score : {currentScore.ToString("N2")}";

        if (currentScore > bestScore)
        {
            PlayerPrefs.SetFloat("BestScore", currentScore);
        }
    }


    private void RankingSet(float currentScore, string currentName)
    {
        // �ϴ��� ���翡 ����
        PlayerPrefs.SetString("CurrentPlayerName", currentName);
        PlayerPrefs.SetFloat("CurrentPlayerScore", currentScore);

        float score = 0f;
        string Name = "";

        for (int i = 0; i < 5; i++)
        {
            // ����� �ְ������� �̸� ��������
            bestScores[i] = PlayerPrefs.GetFloat(i + "BestScore");
            bestName[i] = PlayerPrefs.GetString(i + "BestName");

            // ���� ������ ��ŷ�� ���� �� �ִٸ�
            while (bestScores[i] < currentScore)
            {
                // ���� ( ���� i���� �ӹ��� �ִ� �����͸� ���� �����ͷ� ������ �� �ڸ��� ���ο� �����͸� �ִ� �ڸ��ٲٱ� )
                score = bestScores[i];
                Name = bestName[i];
                bestScores[i] = currentScore;
                bestName[i] = currentName;

                // ��ŷ�� �ٽ� �����ϱ�
                PlayerPrefs.SetFloat(i + "BestScore", currentScore);
                PlayerPrefs.SetString(i.ToString() + "BestName", currentName);

                // ���� �ݺ��� ����
                currentScore = score;
                currentName = name;
            }
        }
        // ������������ ����
        Array.Sort(bestScores);
        Array.Sort(bestName);
    }
    public void GameOver()
    {
        nowScoreTxt.text = $"{currentScore.ToString("N2")}";
        HighScoreText.text = $"{bestScore.ToString("N2")}";
        endPanel.SetActive(true);
    }
}
