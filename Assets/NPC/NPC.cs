using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{   
    public NavMeshAgent agent;
    Animator animator;
    [SerializeField]
    public Transform[] waypoints;
    public Transform player;
    public float attack_distance = 0.3f;
    public float range = 3f;
    public int waypoint_index = 0;
    
    float accuracy = 2f;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }


    public void Move(Transform destination)
    {
/*         if(Vector3.Distance(waypoints[currentwp].transform.position, this.transform.position) < accuracy)
        {
            currentwp++;
            if(currentwp >= waypoints.Length)
            {
                currentwp = 0;
            }
        } */
        agent.SetDestination(destination.position);
        //Debug.Log("Destination set" + agent.destination); 
    }

    void Update()
    {   
       //Debug.Log(agent.remainingDistance);
       /* if(Vector3.Distance(agent.destination, transform.position) <= agent.stoppingDistance)
        {   
            Debug.Log("Destination Reached");
       //Move(waypoints[waypoint_index].transform.position);
        if(agent.remainingDistance >= 0.1f)
        //if(Vector3.Distance(waypoints[waypoint_index].transform.position, this.transform.position) > accuracy)
        {   
            Debug.Log("Destination Reached");
            waypoint_index++;
            Debug.Log("Next Destination set");
            if(waypoint_index >= waypoints.Length)
            {
                waypoint_index = 0;
                Debug.Log("Destination reset");
            }
           
            //animator.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);  
        } */
        
            
    }
    

    
}
