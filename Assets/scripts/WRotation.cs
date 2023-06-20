using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WRotation : MonoBehaviour
{
    
    public float direction = 1;
    public bool isMoveing; 
    
    // Start is called before the first frame update
    void Start()
    {
        isMoveing = false; 
         
    }

    // Update is called once per frame
    void Update()
    {
       if (isMoveing)
        {
            transform.Rotate(new Vector3(0f, 50f * direction * Time.deltaTime, 0f), Space.Self);
        }
    }

   
}
