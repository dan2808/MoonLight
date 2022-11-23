using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
    public float moveSpeed;
    public float walkSpeed;
    public float runSpeed;
    public float rotationSpeed;
    
    private CharacterController controller;
    private Animator anim;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        
    }

    void Update()
    {   
        Move();        
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;
        //movementDirection.Normalize();

        if(movementDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
        {
            Walk();
        }
        else if(movementDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
        {
            Run();
        }
        else if(movementDirection == Vector3.zero)
        {
            Idle();
        }
        
        controller.SimpleMove(movementDirection * moveSpeed);
        //rotate
        if(movementDirection != Vector3.zero)
        {
        Quaternion toRotation = Quaternion.LookRotation(movementDirection);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed*Time.deltaTime);
        }
    }
    private void Walk()
    {
        moveSpeed = walkSpeed;
        anim.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);

    }
    private void Run()
    {   
        moveSpeed = runSpeed;
        anim.SetFloat("Speed", 1, 0.1f, Time.deltaTime);
    }

    private void Idle()
    {
        anim.SetFloat("Speed", 0, 0.1f, Time.deltaTime);
    }
}
