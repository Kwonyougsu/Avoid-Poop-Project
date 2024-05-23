using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    public void SetDifficulty(float interval)
    {
        DataManger.instance.diff = interval;
        SceneManager.LoadScene("MainScene");
    }    
}
