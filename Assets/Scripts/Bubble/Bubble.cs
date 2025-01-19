using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    private bool canMove = false;
    [SerializeField]
    private float bubbleMoveSpeed;
    void Update()
    {
        //模拟Player的Input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 dir = new Vector2(horizontal,vertical);

        BubbleMove(canMove,dir);
    }

    public void BubbleMove(bool canMove,Vector2 dir)
    {
        #if UNITY_EDITOR
        Debug.Log("BubbleMove OK");
        #endif

        //随机速度
        bubbleMoveSpeed = Random.Range(0,0.5f);

        Vector2 targetPos = new Vector2(transform.position.x+bubbleMoveSpeed*dir.normalized.x,transform.position.y+bubbleMoveSpeed*dir.normalized.y);
        transform.position = Vector2.Lerp(transform.position,targetPos,Time.deltaTime);
    }
}
