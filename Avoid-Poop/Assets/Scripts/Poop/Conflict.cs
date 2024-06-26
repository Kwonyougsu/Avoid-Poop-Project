using System;
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

    AudioSource audioSource;
    public AudioClip Poop;
    public AudioClip Heal;
    public AudioClip shieldsound;
    public AudioClip clear;
    public AudioClip fever;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }


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
                PlaySound(Poop);
                Debug.Log(audioSource);
                Debug.Log(Poop); 
                HPManager.hp -= 1;
            }

            if (HPManager.hp == 0)
            {
                ScoreManager.Instance.GameOver(); 
                GameObject[] poopObjects = GameObject.FindGameObjectsWithTag("Poop");                
                foreach (GameObject poop in poopObjects)                
                    Destroy(poop);                
            }
            
        }

        if (other.gameObject.tag == "Item")
        {  
            //보호막         
            if(other.gameObject.name=="ShieldItem(Clone)")
            {   
                if(!isShield)
                {
                    PlaySound(shieldsound);
                    isShield =true;
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
                    PlaySound(Heal);
                    HPManager.hp += 1;
                }
                else
                {
                    Debug.Log("HP max(BonusScore)");
                }
            }
            
            //똥전부제거
            else if(other.gameObject.name=="Clear(Clone)")
            {   
                PlaySound(clear);
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
        float flashTime = 2.0f;
        yield return new WaitForSeconds(time-flashTime); 
        StartCoroutine(FlashShield(flashTime));

        yield return new WaitForSeconds(flashTime);
        Destroy(obj);
        isShield = false;
    }
    IEnumerator FlashShield(float flashTime)
    {
        SpriteRenderer shieldRenderer = obj.GetComponent<SpriteRenderer>();
        float flashInterval = 0.2f; // 깜빡이 반복시간
        float elapsedTime = 0f;

        while (elapsedTime < flashTime)
        { 
            shieldRenderer.enabled = !shieldRenderer.enabled;
            yield return new WaitForSeconds(flashInterval);
            elapsedTime += flashInterval;
        } 
    }

    private void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip); 
            //bgm 같은경우는 play , 효과음은 play one shot 
        }
    }
}
