using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float x = Random.Range(-8f, 8f);
        float y = 6f;

        transform.position = new Vector3(x, y, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Poop")
        {

        }
        else
        {
             Destroy(this.gameObject);
        }
    }




}
