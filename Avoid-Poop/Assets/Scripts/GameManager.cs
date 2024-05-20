using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Poop;

    void Start()
    {
        float interval = DiffManager.Instance.GetDifficulty();
        SetDifficulty(interval);
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


}
