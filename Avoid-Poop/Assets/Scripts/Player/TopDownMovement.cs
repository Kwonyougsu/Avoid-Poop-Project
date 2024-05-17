using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class TopDownMovement: MonoBehaviour
{
    private TopDownController controller;
    private Rigidbody2D movementRigidbody;
    private Vector2 movementDirection; 
    private TopDownAimRotation aim;    
    public GameObject[] charNum;
    private Animator anim;
    [SerializeField] private int speed=5;
    
    private void Awake()
    {
        controller = GetComponent<TopDownController>();
        movementRigidbody=GetComponent<Rigidbody2D>();
        aim=GetComponent<TopDownAimRotation>();
        charNum[DataManger.instance.charNum].SetActive(true);
        aim.InitCharRenderer(charNum[DataManger.instance.charNum].GetComponent<SpriteRenderer>());
    }

    private void Start()
    {
        controller.OnMoveEvent +=  Move;
        anim=GetComponentInChildren<Animator>();   
    }
    private void Move(Vector2 dire)
    {
        movementDirection=dire;
        if(dire.magnitude>0)
        { 
            anim.SetBool("isMove",true);
        }
        else 
            anim.SetBool("isMove",false);
    }
    private void FixedUpdate() 
    {
        //물리업데이트 관련
        //rigibody의 값 바꾸니까
        AppiyMovemant(movementDirection);
    }
    private void AppiyMovemant(Vector2 dire)
    {
        dire=dire*speed;
        movementRigidbody.velocity=dire;
    }

}

