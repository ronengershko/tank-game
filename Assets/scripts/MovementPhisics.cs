using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPhisics : MonoBehaviour
{
    Rigidbody rg;
    public float speeder;
   
    Vector3 mover;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 mover =new Vector3(speeder, 0, speeder);
        rg = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Moveforward()
    {
      
        
        rg.AddForce(transform.forward * speeder);
    }
    public void Movebackward()
    {
     
        
        rg.AddForce(-transform.forward*speeder);
       
    }
    public void Turnleft()
    {
        rg.angularVelocity = new Vector3(0,-2,0);
    }
    public void Turnright()
    {
        rg.angularVelocity = new Vector3(0, 2, 0);
             
    }
    

}
