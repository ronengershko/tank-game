using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMotion : MonoBehaviour
{
    public Vector3 final;
    public int speed = 10; 

   
    // Start is called before the first frame update
    void Start()
    {
        final = transform.position + new Vector3(100, 0, 0); 
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, final, speed); 
        
    }
}
