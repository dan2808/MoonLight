using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Orbit : MonoBehaviour
{
    public GameObject target;

    
    // Update is called once per frame
    void Update()
    {
      transform.RotateAround(target.transform.position, Vector3.back, 20 * Time.deltaTime);
      //transform.LookAt(Vector3.one);
    
      

    }
}
