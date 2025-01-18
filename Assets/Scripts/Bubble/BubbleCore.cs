using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using System.Numerics;
using Unity.Collections;
using UnityEditor;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class BubbleCore : MonoBehaviour
{
    #region Variants
    [SerializeField]
    private float high = 480;
    [SerializeField]
    private float width = 640;
    [SerializeField]
    static private int bubbles = 15;
    [SerializeField]
    private GameObject[] bubblesObj;
    [SerializeField]
    private float radius =30;
    [SerializeField]
    private Sprite bubbleSprite;

    //位置信息数组
    private float[] x = new float[bubbles]; 
    private float[] y = new float[bubbles];
    //速度信息数组
    private float[] speed_x = new float[bubbles]; 
    private float[] speed_y = new float[bubbles];



    private int CPP_RAND_MAX = 32767;
    private Vector2 worldPosLeftBottom;
    private Vector2 worldPosTopRight;
#endregion


    private void Awake() 
    {
        BubbleInit();
    }

    private void Update() 
    {

    }


#region BubbleMovementSystem
    void BubbleInit()
    {
        //初始化赋随机值
        for(int i = 0;i<bubbles;i++)
        {
            //限制生成在屏幕范围内
            // worldPosLeftBottom = Camera.main.ViewportToWorldPoint(Vector2.zero);
            // worldPosTopRight = Camera.main.ViewportToWorldPoint(Vector2.one);

            y[i] = Random.Range(0,CPP_RAND_MAX)% (high-4*radius)+2*radius;
            x[i] = Random.Range(0,CPP_RAND_MAX)% (width - 4*radius)+2*radius;
            // y[i] = Mathf.Clamp(y[i],worldPosLeftBottom.y,worldPosTopRight.y);
            // x[i] = Mathf.Clamp(x[i],worldPosLeftBottom.x,worldPosTopRight.x);

            speed_y[i] = Random.Range(0,2) == 0?1:-1;
            speed_x[i] = Random.Range(0,2) == 0?1:-1;
        }

        //"绘制"bubble
        for(int i = 0;i<bubbles;i++)
        {
            Vector2 objPos = new Vector2(x[i],y[i]);
            bubblesObj[i].transform.position = objPos;
        }

        #if UNITY_EDITOR
        Debug.Log("Init OK");
        #endif
    }

    void BubbleMove()
    {
        //更新bubble坐标
        for(int i = 0;i<bubbles;i++)
        {
            y[i] += speed_y[i];
            x[i] += speed_x[i];
        }

        //判断是否撞墙
        for(int i = 0;i<bubbles;i++)
        {
            if((x[i] <= radius) || (x[i]>=width - radius))
                speed_x[i] = -speed_x[i];
            if((y[i]<=radius) || (y[i]>=high - radius))
                speed_y[i] = -speed_y[i];
        }

        //record1记录原小球编号、2记录距离
        float[,] record = new float[bubbles,2];
        //record数组赋值初始化
        for(int i = 0;i<bubbles;i++)
        {
            record[i,0] = 9999999;
            record[i,1] = -1;
        }
        
        //求所有小球两两间距离平方
        for(int i = 0;i<bubbles;i++)
        {
            for(int n = 0;n<bubbles;n++)
            {
                if(i!=0)
                {
                    //勾股定理
                    float dist2;
                    dist2 = (x[i] - x[n])*(x[i]-x[n]) +
                            (y[i] - y[n])*(y[i] - y[n]);

                    if(dist2 < record[i,0])
                    {
                        //类似于函数的极限，两个动态的量进行比较最终record会被赋予最小的那个数
                        //此最小的数就是第i个小球距离它最近的小球的距离的平方
                        record[i,0] = dist2;
                        record[i,1] = n;
                    }
                }
            }
        }

        //判断球和球之间会不会相撞
        for(int i = 0;i<bubbles;i++)
        {
            if(record[i,0] <= 4* radius *radius)
            {
                int t = (int)record[i,1];

                //进行速度交换
                int temp;
                temp = (int)speed_x[i];
                speed_x[i] = speed_x[t];speed_x[t] = temp;
                temp = (int)speed_y[i];
                speed_y[i] = speed_y[t];speed_y[t] = temp;
                

                //因为两个相聚最近的小球有可能因为彼此都是最近的，而发生二次交换速度
                //所以给离球i最近的球重新赋初值，避免交换两次速度
                record[t,0] = 9999999;
                record[t,1] = -1;
            }
        }
    }
    #endregion
}

