using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiffManager : MonoBehaviour
{
    public static DiffManager Instance;

    //���̵� �Է� �� 
    private float difficultyInterval; 

    private void Awake()
    {
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

    public void SetDifficulty(float interval)
    {
        difficultyInterval = interval;
        SceneManager.LoadScene(1);
    }

    public float GetDifficulty()
    {
        return difficultyInterval;
    }
}
