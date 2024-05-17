using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Sprite[] characters;

    public Image choisedimg;

    public void Choisedcharacter(int num)
    {
        choisedimg.sprite=characters[num];
        DataManger.instance.charNum=num;
    }
}
