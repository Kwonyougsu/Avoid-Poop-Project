using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poop : MonoBehaviour
{
    void Start()
    {
        float x = Random.Range(-8f, 8f);
        float y = 6f;

        transform.position = new Vector3(x, y, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {        
        if(other.gameObject.tag == "Poop" || other.gameObject.tag == "Item" )
        {
            // 충돌 무시, 아무것도 하지 않음
        }        
        else
        {
             Destroy(this.gameObject);
        } 
    }
}
