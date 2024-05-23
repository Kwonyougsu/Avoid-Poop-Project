using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RankingManager : MonoBehaviour
{
    private ScoreManager scoreManager;

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
        RankingSet(0, "Unknown");
    }
   
    [ContextMenu("Reset")]
    public void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }

    private void UpdateRankText()
    {
        Ranker1.text = FormatRankText(bestName[0], bestScores[0].ToString("N2"));
        Ranker2.text = FormatRankText(bestName[1], bestScores[1].ToString("N2"));
        Ranker3.text = FormatRankText(bestName[2], bestScores[2].ToString("N2"));
        Ranker4.text = FormatRankText(bestName[3], bestScores[3].ToString("N2"));
        Ranker5.text = FormatRankText(bestName[4], bestScores[4].ToString("N2"));
    }

    private string FormatRankText(string name, string score)
    {
        return $"{name} : {score}";
    }


    private void RankingSet(float currentScore, string currentName)
    {
        // 1위부터 아래로 검사를 하고 만약에 더 높은 점수가 나오면 반복문 돌리면서 1번에서 찾았다고 하면 아래서부터 땡기기
        // 5위부터 위로 변경
        // 현재 점수가 5위 점수보다 높을 시 

        for (int i = 0; i < 5; i++)
        {
            if (currentScore > bestScores[i])
            {
                // 새로운 점수가 기존 점수보다 높을 경우 삽입
                for (int j = 4; j > i; j--)
                {
                    bestScores[j] = bestScores[j - 1];
                    bestName[j] = bestName[j - 1];
                }

                bestScores[i] = currentScore;
                bestName[i] = currentName;
                break;
            }
        }


        // PlayerPrefs에 저장
        for (int j = 0; j < 5; j++)
        {
            PlayerPrefs.SetFloat(j.ToString() + "BestScore", bestScores[j]);
            PlayerPrefs.SetString(j.ToString() + "BestName", bestName[j]);
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
        RankingSet(nowScore, playerName);
        
    }
}
