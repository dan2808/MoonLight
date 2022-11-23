using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent agent;

    public Animator animator;

    void start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if(Vector3.Distance(agent.destination, transform.position)<= agent.stoppingDistance)
        {
            animator.SetBool("isRunning", false);
        }
        
    }

    private void Move()
    {
        agent.SetDestination(player.position);
        SetDestination(player.position);

    }
    private void SetDestination(Vector3 target)
    {   
        animator.SetBool("isRunning", true);
        agent.SetDestination(target);

    }
}
