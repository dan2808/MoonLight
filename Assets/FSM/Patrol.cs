using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : AbstractState
{   
    float distance;

    Animator anim;
/*     public override AbstractState DoState(FSM fsm)
    {   
        Debug.Log("Patrol State entered");
        NPC npc = fsm.GetComponent<NPC>();
        npc.Move(npc.waypoints[npc.waypoint_index].transform.position);
        
        if(npc.agent.remainingDistance < 1f)
        {
            return fsm.idle;
        }
        else
        {
            return this;
        }
    } */
    public override void EnterState(FSM fsm)
    {
        Debug.Log("Patrol State");
        anim = fsm.GetComponent<Animator>();
        NPC npc = fsm.GetComponent<NPC>();
        npc.Move(npc.waypoints[npc.waypoint_index]);
        //anim.SetFloat("Speed", 0.4f); 
    }

    public override void UpdateState(FSM fsm)
    {   
        NPC npc = fsm.GetComponent<NPC>();
        if(Vector3.Distance(npc.agent.destination, npc.transform.position) <= npc.agent.stoppingDistance)
        {
            Debug.Log("Destination Reached");
            if(npc.waypoint_index<npc.waypoints.Length-1)
            {
                npc.waypoint_index++;
            }  
            else
            {
                npc.waypoint_index=0;
            }
                
            fsm.SwitchState(fsm.idle);
        }
        else if((Vector3.Distance(npc.transform.position, npc.player.position) <= npc.range))
        {
            fsm.SwitchState(fsm.chase);
        }
    }

}
