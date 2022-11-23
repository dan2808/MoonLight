using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="PatrolState", menuName ="Unity-FSM/States/Patrol")]
public class PatrolState : AbstractFSMState
{

    PatrolPoint[] _patrolPoint;
    int _patrolPointIndex;

    public override void OnEnable()
    {
        base.OnEnable();
        _patrolPointIndex = -1;
    }

    public override bool EnterState()
    {   
        if(base.EnterState())
        {
            //Grab and store patrol points
        }
        return base.EnterState();
    }

    public override void UpdateState()
    {
        
    }

    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
