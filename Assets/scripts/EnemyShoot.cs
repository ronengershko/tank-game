using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{

    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject fireMissile;
    public Transform cannonend;
    public Transform fireLunch;
    public int ammo_fireMissiles = 10;
    public int ammo_projectiles = 10;

    
    public float LoadingTime = 0.8f;
    private bool isLoading = false;


    public void Update()
    {
        if (isLoading)
        {
            LoadingTime -= 1 * Time.deltaTime;

            if (LoadingTime <= 0)
            {
                LoadingTime = 0.8f;
                isLoading = false;

            }
        }
    }

    public void ShootMissile()
    {
        if (ammo_fireMissiles > 0 && !isLoading)
        {
            isLoading = true;
            GameObject _object;

            _object = Instantiate(fireMissile, fireLunch.position, fireLunch.rotation) as GameObject;

            
            _object.GetComponent<Rigidbody>().AddForce(fireLunch.forward * 1750);
            --ammo_fireMissiles;
            
        }
    }
    public void ShootProjectile()
    {
  
        if (ammo_projectiles > 0 && !isLoading)
        {
            isLoading = true;
            GameObject _object;

            _object = Instantiate(projectile, cannonend.position, cannonend.rotation) as GameObject;

            
            _object.GetComponent<Rigidbody>().AddForce(cannonend.forward * 1750);

            --ammo_projectiles;
           
        }
    }



}


