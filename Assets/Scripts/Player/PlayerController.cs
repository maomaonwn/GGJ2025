using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 12;

    private void Update()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        //Input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 dir = new Vector2(horizontal,vertical);

        Vector2 targetPos = new Vector2(transform.position.x+moveSpeed*dir.normalized.x,transform.position.y+moveSpeed*dir.normalized.y);

        transform.position = Vector2.Lerp(transform.position,targetPos,Time.deltaTime);
    }
}
