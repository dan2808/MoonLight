using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum ExecutionState
{
        NONE,
        ACTIVE,
        COMPLETED,
        TERMINATED,
};

public abstract class AbstractFSMState : ScriptableObject
{
    protected NavMeshAgent _navMeshAgent;
    protected NPC _npc;
    
    public ExecutionState ExecutionState {get; protected set;}

    public virtual void OnEnable() 
    {
        ExecutionState = ExecutionState.NONE;
        
    }

    public virtual bool EnterState()
    {   
        bool successNavMeshAgentAdded = true;
        bool successNPCAgentAdded = true;
        ExecutionState = ExecutionState.ACTIVE;

        // does the nav agent exists ?
        successNavMeshAgentAdded = (_navMeshAgent != null);
        

        // does the npc executing agent exists ?
        successNPCAgentAdded = (_npc != null);

        return successNavMeshAgentAdded & successNPCAgentAdded;
    }

    public abstract void UpdateState();

    public virtual bool ExitState()
    {   
        ExecutionState = ExecutionState.COMPLETED;
        return true;
    }

    public virtual void SetNavMeshAgent(NavMeshAgent navMeshAgent)
    {
        if(navMeshAgent != null)
        {
            _navMeshAgent = navMeshAgent;
        }
    }

    public virtual void SetExecutingNPC(NPC npc)
    {
        if(npc != null)
        {
            _npc = npc;
        }
    }
}
