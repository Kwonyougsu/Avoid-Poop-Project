using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Diff : MonoBehaviour
{
    public void SetDifficulty(float interval)
    {
        DiffManager.Instance.SetDifficulty(interval);
        BGMManager.Instance.OnDestroy();
    }
}
