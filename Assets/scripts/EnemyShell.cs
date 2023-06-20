using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShell : MonoBehaviour
{

    public float boom_radius = 15f;

    public float demage = 8;
    public float force = 3f;
    public float lifetime = 4f;
    public AudioSource boom_sound;
    public ParticleSystem p_boom;
    public LayerMask playerLayer;
    public LayerMask groundLayer;
    public LayerMask obstaclesLayer; 
    
  

    // Start is called before the first frame update
    void Start()
    {
        if(!(gameObject.name == "EnemyShelli"))
        {
            demage = 16; force = 3f; boom_radius = 20f;
        }
        // Debug.Log("strat boom");
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        p_boom.Play();
    }
    private void OnTriggerEnter(Collider other)
    {
         
      

        Collider[] playercolliders = Physics.OverlapSphere(transform.position, boom_radius, playerLayer);
        Collider[] gruondcolliders = Physics.OverlapSphere(transform.position, boom_radius, groundLayer);
       
        for (int i = 0; i < playercolliders.Length; i++)
        {

            Rigidbody rg_target = playercolliders[i].GetComponent<Rigidbody>();
            if (!rg_target) continue;
            
            rg_target.AddExplosionForce(force, transform.position, boom_radius);
            HealthScript healthSc = rg_target.GetComponent<HealthScript>();


            if (!healthSc) continue;
            healthSc.effectHealth(-demage);


        }
        

        
        p_boom.transform.parent = null;
        p_boom.transform.position = transform.position;

     
        p_boom.Play();


    
        boom_sound.Play();


        Destroy(p_boom.gameObject, 6);


        Destroy(gameObject);
    }

}
