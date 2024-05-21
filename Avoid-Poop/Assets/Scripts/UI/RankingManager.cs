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
    private float[] rankScore = new float[5];
    private string[] rankName = new string[5];
    private float nowScore;
    private string playerName;

    private void Start()
    {
        Ranker1.text = $"{rankName[0]} : {rankScore[0]}";
        Ranker2.text = $"{rankName[1]} : {rankScore[1]}";
        Ranker3.text = $"{rankName[2]} : {rankScore[2]}";
        Ranker4.text = $"{rankName[3]} : {rankScore[3]}";
        Ranker5.text = $"{rankName[4]} : {rankScore[4]}";
    }

       

    // 현재 플레이어의 점수와 이름을 받아서 실행됨
    private void RankingSet(float currentScore, string currentName)
    {
        int j = 0;

        // 현재에 저장하고 시작
        PlayerPrefs.SetString(j.ToString() + "BestName", currentName);
        PlayerPrefs.SetFloat(j.ToString() + "BestScore", currentScore);

        float score = 0f;
        string Name = "";

        for (int i = 0; i < 5; i++)
        {
            // 저장된 최고점수와 이름 가져오기
            bestScores[i] = PlayerPrefs.GetFloat(i.ToString() + "BestScore");
            bestName[i] = PlayerPrefs.GetString(i.ToString() + "BestName");

            // 현재 점수가 랭킹에 오를 수 있다면
            if (bestScores[i] < currentScore)
            {
                // 스왑한다 ( 현재 랭킹에 있던 점수를 빼내고 빈 자리에 현재 점수를 넣는다. 자리 바꾸기 )
                score = bestScores[i];
                Name = bestName[i];
                bestScores[i] = currentScore;
                bestName[i] = currentName;

                // 랭킹에 저장
                PlayerPrefs.SetFloat(i.ToString() + "BestScore", currentScore);
                PlayerPrefs.SetString(i.ToString() + "BestName", currentName);

                // 다음 반복을 위해서
                currentScore = score;
                currentName = name;
            }

            Debug.Log($"{bestName[0]}");
            Debug.Log($"{bestScores[0]}");
        }
        // 랭킹에 맞춰서 점수와 이름을 저장한다.
        Array.Sort(bestScores);
        Array.Sort(bestName);

        for (int i = 0; i < 5; i++)
        {
            rankScore[i] = PlayerPrefs.GetFloat(i.ToString() + "BestScore");
            rankName[i] = PlayerPrefs.GetString(i.ToString() + "BestName");
        }
    }

    public void PlayerNameSet()
    {
        // TODO :: 이름을 입력했을 때 playerName이 값을 받게 해야함
        playerName = nameInput.text;
        resetBtn.SetActive(true);
        closeBtn.SetActive(true);

        scoreManager = ScoreManager.Instance;

        if (scoreManager == null)
        {
            return;
        }

        nowScore = scoreManager.currentScore;
        Debug.Log(nowScore);
        RankingSet(nowScore, playerName);
    }
}
