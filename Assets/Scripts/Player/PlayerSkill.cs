using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    [SerializeField]
    private float CD_Time = 0f;
    //累加器
    private float timer = 0f;
    private bool COOLDOWN = false;

    private Animator anim;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();    
    }

    void PlayerSkillCooldown()
    {
        if(COOLDOWN)
        {
            timer += Time.deltaTime;

            if(timer >= CD_Time)
            {
                //重置累加器
                timer = 0f;
            }
        }
    }

    void PlayerUseSkill()
    {
        
    }
}
