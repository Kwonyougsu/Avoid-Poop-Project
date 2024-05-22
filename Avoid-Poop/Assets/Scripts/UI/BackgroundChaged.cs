using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundChaged : MonoBehaviour
{
    public Sprite[] sprites;
    public float interval;

    void Start()
    {
        GameObject.Find("BackGround").GetComponent<Image>().sprite = sprites[0];

        interval = DataManger.instance.diff;
        switch (interval)
        {
            case 0.2f:
                GameObject.Find("BackGround").GetComponent<Image>().sprite = sprites[0];
                break;
            case 0.1f:
                GameObject.Find("BackGround").GetComponent<Image>().sprite = sprites[1];
                break;
            case 0.07f:
                GameObject.Find("BackGround").GetComponent<Image>().sprite = sprites[2];
                break;
            default:
                break;
        }

    }

}
