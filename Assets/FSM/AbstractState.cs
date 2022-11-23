using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class AbstractState
{
    //public abstract AbstractState DoState(FSM fsm);

    public abstract void EnterState(FSM fsm);
    public abstract void UpdateState(FSM fsm); 
}
