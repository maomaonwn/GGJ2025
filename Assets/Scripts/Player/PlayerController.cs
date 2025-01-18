using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 12;

    private Vector2 worldPosLeftBottom;
    private Vector2 worldPosTopRight;

    private void Start()
    {
        worldPosLeftBottom = Camera.main.ViewportToWorldPoint(Vector2.zero);
        worldPosTopRight = Camera.main.ViewportToWorldPoint(Vector2.one);    
    }

    private void Update()
    {
        //Input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 dir = new Vector2(horizontal,vertical);

        PlayerMove(dir);
        PlayerRotate(dir);
        PlayerAlwaysTowardMouse();
        Boundary();
    }

    void PlayerMove(Vector2 dir)
    {
        Vector2 targetPos = new Vector2(transform.position.x+moveSpeed*dir.normalized.x,transform.position.y+moveSpeed*dir.normalized.y);

        transform.position = Vector2.Lerp(transform.position,targetPos,Time.deltaTime);
    }

    void PlayerRotate(Vector2 dir)
    {
        if(dir.x != 0 || dir.y != 0)
        {
            //向量与y轴正方向的夹角
            float angle = Mathf.Atan2(dir.x,dir.y)* Mathf.Rad2Deg;
            //绕z轴旋转angle度
            transform.rotation = Quaternion.AngleAxis(-angle,Vector3.forward);
        }
    }

    void PlayerAlwaysTowardMouse()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //朝向鼠标位置的方向
        Vector2 towardDir = mousePos - transform.position;
        float angle = Mathf.Atan2(towardDir.x,towardDir.y)*Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(-angle,Vector3.forward);
    }
    
    void Boundary()
    {
        Vector3 clampedPos = new Vector3(Mathf.Clamp(transform.position.x,worldPosLeftBottom.x,worldPosTopRight.x),
                                         Mathf.Clamp(transform.position.y,worldPosLeftBottom.y,worldPosTopRight.y),
                                         0);
        transform.position = clampedPos; 
    }
}