using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using Unity.Collections;
using UnityEditor;
using UnityEngine;

public class BubbleCore : MonoBehaviour
{
    [SerializeField]
    static private int bubbleNum = 15;
    [SerializeField]
    private GameObject[] bubblesObj;


    //位置信息数组
    private float[] x = new float[bubbleNum]; 
    private float[] y = new float[bubbleNum];

    private Rigidbody2D rb2D;

    private void Start() 
    {
        rb2D = GetComponent<Rigidbody2D>();

        BubbleInit();
    }

    private void BubbleInit()
    {
        //随机生成位置
        for(int i = 0;i<bubbleNum;i++)
        {
            y[i] = Random.Range(-30,30);
            x[i] = Random.Range(-30,30);
            //给bubble坐标赋值
            Vector3 objPos = new Vector3(x[i],y[i],0);
            bubblesObj[i].transform.position = objPos;
        }

        #if UNITY_EDITOR
        Debug.Log("Init OK");
        #endif
    }

}











//     void EdgeCollisionCheck()
//     {
        
//         float leftBorder = Camera.main.transform.position.x - (worldPosTopRight.x - Camera.main.transform.position.x);
//         float rightBorder = worldPosTopRight.x;
//         float topBorder = worldPosTopRight.y;
//         float downBorder = Camera.main.transform.position.y - (worldPosTopRight.y - Camera.main.transform.position.y);

//         float width = rightBorder - leftBorder;
//         float height = topBorder - downBorder;

//         //抵达边界
//         if(transform.localPosition.y >=topBorder){AfterCollision();}
//         if(transform.localPosition.y <= downBorder){AfterCollision();}
//         if(transform.localPosition.x <= leftBorder){AfterCollision();}
//         if(transform.localPosition.x >= rightBorder){AfterCollision();}
//     }
    // void Boundary()
    // {
    //     foreach(GameObject bubble in bubblesObj)
    //     {
    //         Vector3 clampedPos = new Vector3(Mathf.Clamp(transform.position.x,worldPosLeftBottom.x,worldPosTopRight.x),
    //                                          Mathf.Clamp(transform.position.y,worldPosLeftBottom.y,worldPosTopRight.y),
    //                                          0);
    //         bubble.transform.position = clampedPos; 
    //     }
    // }
