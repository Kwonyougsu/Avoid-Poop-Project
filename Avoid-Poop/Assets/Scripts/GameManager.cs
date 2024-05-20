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
        InvokeRepeating("MakePoop", 0f, 0.2f);
        InvokeRepeating("MakeItem", 0f, 3f);
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
