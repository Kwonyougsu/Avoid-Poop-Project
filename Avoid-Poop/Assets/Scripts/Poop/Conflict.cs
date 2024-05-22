using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Conflict : MonoBehaviour
{
    HPManager HPManager;
    public GameObject shield;
    public float destroyTime = 5f;
    public bool isShield;
    private Coroutine shieldCoroutine;
    GameObject obj;
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "Poop")
        {
            if(isShield)
            {
                Debug.Log("Shield");
            }
            else
            {
            Debug.Log("Ouch");
            HPManager.hp -= 1;
            }
            if (HPManager.hp == 0)
            {
                ScoreManager.Instance.GameOver();
                BGMManager.Instance.OnDestroy();
            }
            
        }

        if (other.gameObject.tag == "Item")
        {  
            //보호막         
            if(other.gameObject.name=="ShieldItem(Clone)")
            {   
                if(!isShield)
                {
                    isShield=true;
                    // Shield 프리팹을 인스턴스화하고 위치 설정
                    obj = Instantiate(shield, transform);
                } 
                // 이미 활성화된 코루틴이 있으면 중지합니다.
                else
                {
                    StopCoroutine(shieldCoroutine);
                }
                //코루틴 실행
                shieldCoroutine = StartCoroutine(DisableShieldAfterTime(destroyTime));
                                 
            }
            //체력회복 
            else if(other.gameObject.name=="Heal(Clone)")
            {
                
                if(HPManager.hp < 5)
                {
                Debug.Log("Heal");
                HPManager.hp += 1;
                }
                else
                {
                    Debug.Log("HP max(BonusScore)");
                }
            }
            //점수2배 아이탬
            else if(other.gameObject.name=="Fever(Clone)")
            {
                Debug.Log("Fever");
                //난이도에따른 점수계산구현후 추가구현할예정
            }
            //똥전부제거
            else if(other.gameObject.name=="Clear(Clone)")
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
    // 코루틴 사용 정해진시간이후에 값변경
    IEnumerator DisableShieldAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(obj);
        isShield = false;
    }

}
