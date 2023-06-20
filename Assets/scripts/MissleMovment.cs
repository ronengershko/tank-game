using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 
public class MissleMovment : MonoBehaviour
{
    public int x;
    // Start is called before the first frame update
    Rigidbody rg;
    ParticleSystem ps;
    void Start()
    {
        rg = GetComponent<Rigidbody>();
        //ps = GetComponent<ParticleSystem>();
        
        rg.AddForce(0, x, 0);

        ParticleSystem ps = GetComponent<ParticleSystem>();
        var vel = ps.velocityOverLifetime;
        vel.enabled = true;
        vel.space = ParticleSystemSimulationSpace.Local;

        AnimationCurve curve = new AnimationCurve();
        curve.AddKey(0.0f, 1.0f);
        curve.AddKey(1.0f, 0.0f);
        vel.x = new ParticleSystem.MinMaxCurve(10.0f, curve);




    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        ReciveDamageScript rec = other.gameObject.GetComponent<ReciveDamageScript>();
        if (rec != null)
        {
            rec.ReciveDamage(3);
            Debug.Log("Trigger");
        }
        Rigidbody _rigidBody = other.gameObject.GetComponent<Rigidbody>();
        if (_rigidBody != null)
        {
            _rigidBody.AddForceAtPosition(transform.up * 500.0f, transform.position);
        }
    }
}
