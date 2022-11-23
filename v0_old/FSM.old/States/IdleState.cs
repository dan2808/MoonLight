using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="IdleState", menuName ="Unity-FSM/States/Idle")]
public class IdleState : AbstractFSMState
{
    public override bool EnterState()
    {
        base.EnterState();
        Debug.Log("Entered IDLE STATE");
        return true;
    }
    public override void UpdateState()
    {
        Debug.Log("UPDATING IDLE STATE");
    }

    public override bool ExitState()
    {
        base.ExitState();
        Debug.Log("Exited IDLE STATE");
        return true;
        
    }
}
