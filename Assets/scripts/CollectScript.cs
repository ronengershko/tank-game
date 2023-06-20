using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectScript : MonoBehaviour
{
    public ShootScript ammo;
    public HealthScript health;
    public GameFlow GameFlow; 
    // Start is called before the first frame update
    void Start()
    {
        ammo = transform.GetComponent<ShootScript>();
        health = transform.GetComponent<HealthScript>();
    }

   

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "fire")
        {
           
            ammo.ammo_fireMissiles += 20;
            GameFlow.ammocounter(ammo.ammo_fireMissiles, ammo.ammo_projectiles);
            Destroy(other.gameObject);
        }
        if(other.name == "fix")
        {  
            
            health.effectHealth(15);
            Destroy(other.gameObject);

        }
        if(other.name == "pro")
        {
            
            ammo.ammo_projectiles += 10;
            GameFlow.ammocounter(ammo.ammo_fireMissiles, ammo.ammo_projectiles);
            Destroy(other.gameObject);
        }
    }

}
