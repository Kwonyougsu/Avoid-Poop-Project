using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManger : MonoBehaviour
{
    public static DataManger instance;
    public string userName;
    public int charNum;
    public float diff;
    
    //DataManager.instance.userName = 으로 값받아옴
    private void Awake() 
    {
        Time.timeScale = 1.0f;
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }    
}
