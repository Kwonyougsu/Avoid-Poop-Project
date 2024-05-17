using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Poop;
    public static GameManager Instance;
    public GameObject endPanel;

    void Start()
    {
        InvokeRepeating("MakePoop", 0f, 0.1f);
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void MakePoop()
    {
        Instantiate(Poop);
    }

    public void GameOver()
    {
        endPanel.SetActive(true);
    }
}
