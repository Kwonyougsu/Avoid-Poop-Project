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
    

    private void Awake()
    {
        Ranker1.text = $"{bestName[4]} : {bestScores[4]}";
        Ranker2.text = $"{bestName[3]} : {bestScores[3]}";
        Ranker3.text = $"{bestName[2]} : {bestScores[2]}";
        Ranker4.text = $"{bestName[1]} : {bestScores[1]}";
        Ranker5.text = $"{bestName[0]} : {bestScores[0]}";
        bestScore = PlayerPrefs.GetFloat("BestScore", 0);
        highScoreText.text = $"HIGH : {bestScore.ToString("N2")}";
    }

    void Start()
    {
        Time.timeScale = 1f; 
    }

    // Update is called once per frame
    void Update()
    {
        Score();
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
        // 일단은 현재에 저장
        PlayerPrefs.SetString("CurrentPlayerName", currentName);
        PlayerPrefs.SetFloat("CurrentPlayerScore", currentScore);

        float score = 0f;
        string Name = "";

        for (int i = 0; i < 5; i++)
        {
            // 저장된 최고점수와 이름 가져오기
            bestScores[i] = PlayerPrefs.GetFloat(i + "BestScore");
            bestName[i] = PlayerPrefs.GetString(i + "BestName");

            // 현재 점수가 랭킹에 오를 수 있다면
            while (bestScores[i] < currentScore)
            {
                // 스왑 ( 현재 i번에 머물러 있는 데이터를 더미 데이터로 빼내고 빈 자리에 새로운 데이터를 넣는 자리바꾸기 )
                score = bestScores[i];
                Name = bestName[i];
                bestScores[i] = currentScore;
                bestName[i] = currentName;

                // 랭킹에 다시 저장하기
                PlayerPrefs.SetFloat(i + "BestScore", currentScore);
                PlayerPrefs.SetString(i.ToString() + "BestName", currentName);

                // 다음 반복을 위해
                currentScore = score;
                currentName = name;
            }
        }
        // 오름차순으로 정렬
        Array.Sort(bestScores);
        Array.Sort(bestName);
    }
}
