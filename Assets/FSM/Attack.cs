using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : AbstractState
{
    
    public override void EnterState(FSM fsm)
    {
        Debug.Log("Attack");
    }

    
    public override void UpdateState(FSM fsm)
    {   
        NPC npc = fsm.GetComponent<NPC>();
        if(Vector3.Distance(npc.transform.position, npc.player.position) >= npc.attack_distance)
        {
            fsm.SwitchState(fsm.chase);
        }
        
    }
}
