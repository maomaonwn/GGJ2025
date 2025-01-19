using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistrictCheck : MonoBehaviour
{
    [SerializeField]
    private BoxCollider2D victoryDistrict;
    private int victoryCount = 0;

    private void Update() 
    {
        if(victoryCount == 3)TriggerGameWin();
    }


    void OnTriggerEnter2D(Collider2D other) 
    {
        #if UNITY_EDITOR
        Debug.Log("TriggerEnter OK!");
        #endif

        if(other.CompareTag("Bubble"))
        {
            victoryCount++;
        }    
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        #if UNITY_EDITOR
        Debug.Log("TriggerExit OK!");
        #endif

        if(other.CompareTag("Bubble"))
        {
            victoryCount--;
        }    
    }

    void TriggerGameWin()
    {
        Time.timeScale = 0f;
    }
}
