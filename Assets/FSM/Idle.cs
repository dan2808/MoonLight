using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : AbstractState
{   
    float idleDuration = 3f;

    Animator anim;

    public override void EnterState(FSM fsm)
    {
        Debug.Log("Idle State");
        anim = fsm.GetComponent<Animator>();
        anim.SetFloat("Speed", 0f);

    }

    public override void UpdateState(FSM fsm)
    {
        if(idleDuration >= 0f)
        {
            idleDuration -= Time.deltaTime;           
        }
        else
        {   
            idleDuration = 3f;
            fsm.SwitchState(fsm.patrol);
        }
         
    }


   /*  public override AbstractState DoState(FSM fsm)
    {   
        Debug.Log("Idle State entered");
        anim = fsm.GetComponent<Animator>();
        //anim.SetFloat("Speed", 0, 0.1f, Time.deltaTime);
        //anim.SetFloat("Speed", 0);
    
        totalDuration += Time.deltaTime;
        //Debug.Log(totalDuration);

        if(totalDuration > idleDuration)
        {   
            totalDuration=0;
            return fsm.patrol;
            
        }
        else
        {
            return this;
        }
        
    } */
}
