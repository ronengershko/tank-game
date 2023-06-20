using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardPhisics : MonoBehaviour
{
    // Start is called before the first frame update
   // public MovementPhisics move;
    public ShootScript shoot;
    void Start()
    {
      //  move = GetComponent<MovementPhisics>();
        shoot = GetComponent<ShootScript>();
    }

    // Update is called once per frame
    void Update()
    {
       /* if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
        {

            move.Turnleft();
            move.Moveforward();
        }
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
        {
            move.Turnright();
            move.Moveforward();
        }
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
        {
            move.Turnleft();
            move.Movebackward();
          
        }
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
        {
            move.Turnright();
            move.Movebackward();
        }

        if (Input.GetKey(KeyCode.A))
        {
            move.Turnleft();
        }
        if (Input.GetKey(KeyCode.D))
        {
            move.Turnright();
        }
        if (Input.GetKey(KeyCode.S))
        {
            move.Movebackward(); 
        }
        if (Input.GetKey(KeyCode.W))
        {
            move.Moveforward();
        }*/
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //shoot.ShootBullets();
           // Debug.Log("here"); 
            shoot.ShootMissile();
           // Debug.Log("here2");

        }
        if (Input.GetButtonDown("Fire1"))
        {
            shoot.ShootProjectile();
        } 
    }
}
