using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    private static BGMManager instance = null;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            GetComponent<AudioSource>().Play();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
