using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerController : MonoBehaviour
{
    public Camera cam;

    public NavMeshAgent agent;

    public Animator animator;

    void start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {   
            ClickToMove();
        }

        if(Vector3.Distance(agent.destination, transform.position)<= agent.stoppingDistance)
        {
            animator.SetBool("isRunning", false);
        }
    }   
    private void ClickToMove()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            SetDestination(hit.point);
        }
    }

    private void SetDestination(Vector3 target)
    {   
        animator.SetBool("isRunning", true);
        agent.SetDestination(target);

    }
    
}
