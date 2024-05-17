using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonFunction : MonoBehaviour
{
    public void StartBtn()
    {
        //메인 씬으로 이동 
        SceneManager.LoadScene(0);
    }
}
