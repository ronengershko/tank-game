using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectEnemy: MonoBehaviour
{
    public EnemyShoot ammo;
    public HealthScript health;
    // Start is called before the first frame update
    void Start()
    {
        ammo = transform.GetComponent<EnemyShoot>();
        health = transform.GetComponent<HealthScript>();
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "fire")
        {
           
            ammo.ammo_fireMissiles += 20;
            Destroy(other.gameObject);
        }
        if (other.name == "fix")
        {
      
            health.effectHealth(10);
            Destroy(other.gameObject);

        }
        if (other.name == "pro")
        {
         
            ammo.ammo_projectiles += 10;
            Destroy(other.gameObject);
        }
    }

}
