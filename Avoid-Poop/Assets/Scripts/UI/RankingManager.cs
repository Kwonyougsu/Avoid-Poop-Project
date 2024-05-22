using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class RankingManager : MonoBehaviour
{
    public ScoreManager scoreManager;

    [SerializeField] TMP_Text Ranker1;
    [SerializeField] TMP_Text Ranker2;
    [SerializeField] TMP_Text Ranker3;
    [SerializeField] TMP_Text Ranker4;
    [SerializeField] TMP_Text Ranker5;
    [SerializeField] TMP_InputField nameInput;

    public GameObject resetBtn;
    public GameObject closeBtn;

    private float[] bestScores = new float[5];
    private string[] bestName = new string[5];
    private float nowScore;
    private string playerName;

    private void Start()
    {
        // 초기 값이 없으면 기본 값 설정
        for (int i = 0; i < 5; i++)
        {
            if (!PlayerPrefs.HasKey(i.ToString() + "BestScore"))
            {
                PlayerPrefs.SetFloat(i.ToString() + "BestScore", 0f);
                PlayerPrefs.SetString(i.ToString() + "BestName", "Unknown");
            }
            bestScores[i] = PlayerPrefs.GetFloat(i.ToString() + "BestScore");
            bestName[i] = PlayerPrefs.GetString(i.ToString() + "BestName");
        }
        UpdateRankText();
    }

    private void UpdateRankText()
    {
        Ranker1.text = FormatRankText(bestName[0], bestScores[0]);
        Ranker2.text = FormatRankText(bestName[1], bestScores[1]);
        Ranker3.text = FormatRankText(bestName[2], bestScores[2]);
        Ranker4.text = FormatRankText(bestName[3], bestScores[3]);
        Ranker5.text = FormatRankText(bestName[4], bestScores[4]);
    }

    private string FormatRankText(string name, float score)
    {
        return $"{name} : {score}";
    }


    private void RankingSet(float currentScore, string currentName)
    {
        for (int i = 0; i < 5; i++)
        {
            if (currentScore > bestScores[i])
            {
                // 점수와 이름을 스왑
                float tempScore = bestScores[i];
                string tempName = bestName[i];
                bestScores[i] = currentScore;
                bestName[i] = currentName;
                currentScore = tempScore;
                currentName = tempName;
            }
        }

        // PlayerPrefs에 저장
        for (int i = 0; i < 5; i++)
        {
            PlayerPrefs.SetFloat(i.ToString() + "BestScore", bestScores[i]);
            PlayerPrefs.SetString(i.ToString() + "BestName", bestName[i]);
        }

        UpdateRankText();
    }

    public void PlayerNameSet()
    {
        playerName = nameInput.text;
        resetBtn.SetActive(true);
        closeBtn.SetActive(true);

        scoreManager = ScoreManager.Instance;

        if (scoreManager == null)
        {
            Debug.LogError("ScoreManager instance is null.");
            return;
        }

        nowScore = scoreManager.currentScore;
        Debug.Log(nowScore);
        RankingSet(nowScore, playerName);
    }
}
