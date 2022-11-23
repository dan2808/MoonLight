using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : AbstractState
{
    Animator anim;
    public override void EnterState(FSM fsm)
    {
        Debug.Log("Chase State");
        anim = fsm.GetComponent<Animator>();
        NPC npc = fsm.GetComponent<NPC>();
        npc.Move(npc.player);
        //anim.SetFloat("Speed", 0.4f); 

    }

    public override void UpdateState(FSM fsm)
    {   
        NPC npc = fsm.GetComponent<NPC>();
        if(Vector3.Distance(npc.transform.position, npc.player.position) > npc.range)
        {
            fsm.SwitchState(fsm.patrol);
        }
        else if(Vector3.Distance(npc.transform.position, npc.player.position) < npc.attack_distance)
        {
            fsm.SwitchState(fsm.attack);
        }
        else
        {
            npc.Move(npc.player);
        }

    }
    
}
