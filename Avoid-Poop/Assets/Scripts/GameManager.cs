using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Poop;
    public GameObject[] Item;
    public static GameManager Instance;
    public GameObject endPanel;

    void Start()
    {
        float interval = DiffManager.Instance.GetDifficulty();
        SetDifficulty(interval);
        InvokeRepeating("MakeItem", 0f, 3f);
    }

    public void SetDifficulty(float interval)
    {
        CancelInvoke("MakePoop");
        InvokeRepeating("MakePoop", 0f, interval);
    }

    private void Update()
    {
        
    }
    private void MakePoop()
    {
        Instantiate(Poop);
    }

    private void MakeItem()
    {
        int ItemNum = Random.Range(0, 1);
        Instantiate(Item[ItemNum]);
    }

    public void GameOver()
    {
        endPanel.SetActive(true);
    }
}
