using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Poop;

    void Start()
    {
        InvokeRepeating("MakePoop", 0f, 0.1f);
    }
    private void Update()
    {
        
    }

    private void MakePoop()
    {
        Instantiate(Poop);
    }


}
