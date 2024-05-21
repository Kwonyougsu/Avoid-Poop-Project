using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public static BGMManager Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            GetComponent<AudioSource>().Play();
        }
        else
        {
            OnDestroy();
        }
    }
    public void OnDestroy()
    {
        Destroy(gameObject);
    }
}
