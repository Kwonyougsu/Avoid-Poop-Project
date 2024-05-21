using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DiffManager : MonoBehaviour
{
    public static DiffManager Instance;

    //난이도 입력 값 
    private float difficultyInterval;

    private void Awake()
    {
        Time.timeScale = 1.0f;
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //다시 start 씬을 로드할 때, 옵젝이 2개가 되어버림. -> 싱글톤은 직접적으로 넣는것이 아니다. 기능을 끌어다쓴다.
    public void SetDifficulty(float interval)
    {
        difficultyInterval = interval;
        SceneManager.LoadScene("MainScene");
    }
    

    public float GetDifficulty()
    {
        return difficultyInterval;
    }
}
