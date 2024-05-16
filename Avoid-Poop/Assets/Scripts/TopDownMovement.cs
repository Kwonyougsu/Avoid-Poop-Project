using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class TopDownMovement: MonoBehaviour
{
    private TopDownController controller;
    private Rigidbody2D movementRigidbody;
    private Vector2 movementDirection; 
    [SerializeField] private int speed=5;
    
    private void Awake()
    {
        controller = GetComponent<TopDownController>();
        movementRigidbody=GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        controller.OnMoveEvent +=  Move;
    }
    private void Move(Vector2 dire)
    {
        movementDirection=dire;
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

