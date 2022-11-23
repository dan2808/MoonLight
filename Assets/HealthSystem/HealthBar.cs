using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{   
    HealthSystem healthSystem = new HealthSystem(100);
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    public void Setup(HealthSystem healthSystem){

        this.healthSystem = healthSystem;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Find("HealthRepresent").localScale = new Vector3(healthSystem.GetHealthProcent(),1,1);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            healthSystem.Damage(10);
            Debug.Log("Health"+healthSystem.GetHealth());
            Debug.Log(healthSystem.GetHealthProcent());
        }
        else if(Input.GetKeyDown(KeyCode.Backspace))
        {
            healthSystem.Heal(10);
            Debug.Log("Health"+healthSystem.GetHealth());
            Debug.Log(healthSystem.GetHealthProcent());
        }
            

        
    }

    private void LateUpdate() {
        transform.LookAt(Camera.main.transform);
    }
}
