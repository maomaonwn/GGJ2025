using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Breath : MonoBehaviour
{
    //遮掩层防止和其他部分交互
    public LayerMask detectLayer;

    private void Start() 
    {
    }

    private void Update() 
    {
        //模拟Player的Input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 dir = new Vector2(horizontal,vertical);
    }
}






    // private void OnColliderEnter2D(Collider2D other) 
    // {
    //     #if UNITY_EDITOR
    //     Debug.Log("Trigger OK");
    //     #endif

    //     // RaycastHit2D hit = Physics2D.Raycast(transform.position,other.transform.forward,1.5f,detectLayer);
    //     // hit.collider.GetComponent<Bubble>().BubbleMove(true,dir);
    // }

    // public bool Detect(Vector2 dir)
    // {
    //     RaycastHit2D hit = Physics2D.Raycast(transform.position,dir,1.5f,detectLayer);

    //     if(!hit) return false;
    //     else
    //     {
    //         if(hit.collider.GetComponent<Bubble>()!=null)
    //         {
    //             hit.collider.GetComponentInParent<Bubble>().BubbleMove(true,dir);
    //         }
    //         return true;
    //     }
    // }