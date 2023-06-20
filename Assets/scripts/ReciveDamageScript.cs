using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReciveDamageScript : MonoBehaviour
{
    public int hitpoints;
    // Start is called before the first frame update
    void Start()
    {
       // hitpoints = 5;
        
        Debug.Log(gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ReciveDamage(int damage)
    {
        if(hitpoints <= 0)
        {
            Destroy(gameObject);

        }
        else
        {
            hitpoints -= damage;
            Debug.Log(hitpoints);
        }
       

    }
}
