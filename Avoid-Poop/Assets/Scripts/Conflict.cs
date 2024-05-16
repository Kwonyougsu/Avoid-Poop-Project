using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conflict : MonoBehaviour
{
    private GameObject gameOverPanel;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Poop");
        {
            Time.timeScale = 0f;
            gameOverPanel.SetActive(true);
        }
    }
}
