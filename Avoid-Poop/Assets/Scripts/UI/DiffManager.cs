using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DiffManager : MonoBehaviour
{
    public static DiffManager Instance;

    //���̵� �Է� �� 
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

    //�ٽ� start ���� �ε��� ��, ������ 2���� �Ǿ����. -> �̱����� ���������� �ִ°��� �ƴϴ�. ����� ����پ���.
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
