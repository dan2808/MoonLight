using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM : MonoBehaviour
{
    public AbstractState currentState;
    
    public Idle idle = new Idle();
    public Patrol patrol = new Patrol();
    public Chase chase = new Chase();
    public Attack attack = new Attack();

    private void Start()
    {
        currentState = idle;
        currentState.EnterState(this);
    }

    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(AbstractState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
 