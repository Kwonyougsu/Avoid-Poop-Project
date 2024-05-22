using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HPManager : MonoBehaviour
{
    private Image img;
    public static int hp;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public GameObject heart4;
    public GameObject heart5;

    void Start()
    {
        hp = 5;        
    }

    void Update()
    {
        switch (hp)
        {
            case 5:
                heart5.SetActive(true);
                break;
            case 4:
                heart5.SetActive(false);
                heart4.SetActive(true);
                break;
            case 3:
                heart4.SetActive(false);
                heart3.SetActive(true);
                break;
            case 2:
                heart3.SetActive(false);
                heart2.SetActive(true);
                break;
            case 1:
                heart2.SetActive(false);
                break;
            case 0:
                heart1.SetActive(false);                
                break;
        }
    }

    public void PlayerHp()
    {
       
    }
}
