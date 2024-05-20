using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Conflict : MonoBehaviour
{
    HPManager HPManager;
    public GameObject shield;
    public float destroyTime = 5f;
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

        if (other.gameObject.tag == "Item")
        {               
            //보호막         
            if(other.gameObject.name=="ShieldItem")
            {
                Debug.Log("Shield");
                Vector3 playerPos = this.transform.position;
                // Shield 프리팹을 인스턴스화하고 위치 설정
                Instantiate(shield, playerPos, Quaternion.identity);
                // 5초 후에 Shield 프리팹을 파괴
                Destroy(shield, destroyTime);
            }
            //체력회복 
            else if(other.gameObject.name=="Heal")
            {
                Debug.Log("Heal");
                if(HPManager.hp < 5)
                HPManager.hp += 1;
            }
            //점수2배 아이탬
            else if(other.gameObject.name=="Fever")
            {
                Debug.Log("Fever");
                //난이도에따른 점수계산구현후 추가구현할예정
            }
            //똥전부제거
            else if(other.gameObject.name=="Clear")
            {   
                Debug.Log("Clear");
                // "Poop" 태그를 가진 모든 게임 오브젝트를 찾아 배열로 저장           
                GameObject[] poopObjects = GameObject.FindGameObjectsWithTag("Poop");

                // 배열에 저장된 각 게임 오브젝트를 제거
                foreach (GameObject poop in poopObjects)
                {
                    Destroy(poop);
                }
            }
        }
    }

}
