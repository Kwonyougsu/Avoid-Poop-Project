using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HPManager : MonoBehaviour
{
    private Image img;

    public static int hp;
    // 스태틱을 사용하면 -> 메모리에 자리를 차지하고있어서 초기화를 시켜줘야한다. (씬로드를 해도)

    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public GameObject heart4;
    public GameObject heart5;

    void Start()
    {
        hp = 5;
        Time.timeScale = 1.0f;
    }

    void Update()
    {
        switch (hp)
        {
            case 4:
                heart5.SetActive(false);
                break;
            case 3:
                heart4.SetActive(false);
                break;
            case 2:
                heart3.SetActive(false);
                break;
            case 1:
                heart2.SetActive(false);
                break;
            case 0:
                heart1.SetActive(false);
                Time.timeScale = 0f;
                break;
        }
    }

    public void PlayerHp()
    {
       
    }
}
