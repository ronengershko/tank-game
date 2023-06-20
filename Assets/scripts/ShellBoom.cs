using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellBoom : MonoBehaviour
{

    public float boom_radius = 10f;

    public int demage = 15;
    public float force = 3f;
    public float lifetime = 4f;
    public AudioSource boom_sound;
    public ParticleSystem p_boom;
    public LayerMask playerlayer;
    public LayerMask groundlayer;
    public LayerMask enemylayer;

   

    // Start is called before the first frame update
    void Start()
    {
        //boom_sound.Play();
        if ( !(gameObject.name == "shelli"))
        {
           
            demage = 20; force = 3f; boom_radius = 30f;
        }
      
        Destroy(gameObject, lifetime); 
    }

  
    private void OnTriggerEnter(Collider other)
    {
        boom_sound.transform.parent = null;
       
        boom_sound.Play();
        Collider[] playercolliders = Physics.OverlapSphere(transform.position, boom_radius, enemylayer);
       
      
        for (int i = 0; i < playercolliders.Length; i++)
        {  
            
            Rigidbody rg_target= playercolliders[i].GetComponent<Rigidbody>();
            if (!rg_target)
                continue;
            rg_target.AddExplosionForce(force, transform.position, boom_radius);
            HealthScript healthSc = rg_target.GetComponent<HealthScript>();


            if (!healthSc)
                continue;
            healthSc.effectHealth(-demage);
            
            
        }
     
        p_boom.transform.parent = null;
        p_boom.transform.position = transform.position;

       
        p_boom.Play();


       
        //boom_sound.Play();

      
        Destroy(p_boom.gameObject, 6);

   
        Destroy(gameObject);
    }

}
