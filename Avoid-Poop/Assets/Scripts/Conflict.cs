using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conflict : MonoBehaviour
{
    HPManager HPManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Poop")
        {
            Debug.Log("Ouch");
            HPManager.hp -= 1;
            if (HPManager.hp == 0)
            {
                GameManager.Instance.GameOver();
            }
        }
    }

}
