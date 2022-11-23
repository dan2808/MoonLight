using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(FiniteStateMachine))]
public class NPC : MonoBehaviour
{
    NavMeshAgent _navMeshAgent;
    FiniteStateMachine _finiteStateMachine;
    public void awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _finiteStateMachine = GetComponent<FiniteStateMachine>();

    } 
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
