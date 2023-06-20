using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TankMovement : MonoBehaviour
{
    public float speed = 24f;                 
    public float TurnSpeed = 180f;           
         
   
    public NavMeshAgent navy;

    private string movename;       
    private string trunname;             
    private Rigidbody rg;             
    private float move_input;         
    private float turn_input;             
   
    private GameObject[] wheelsLeft;
    private GameObject[] wheelsRight;


    // Start is called before the first frame update
    private void Awake()
    {
          navy.speed = speed; 
      
        wheelsRight = new GameObject[6] ;
        wheelsLeft = new GameObject[6] ; 
        rg = GetComponent<Rigidbody>();
        Getwheels(wheelsLeft, "left", "tank");
        Getwheels(wheelsRight, "right","tank");



    }


 


    private void Start()
    {

     //   transform.forward = new Vector3(1f, 0f, 0f);
        rg = GetComponent<Rigidbody>();
        movename = "Vertical";
        trunname = "Horizontal";
        
    }


    private void Update()
    {
        // Store the value of both input axes.
        move_input = Input.GetAxis(movename);
        turn_input = Input.GetAxis(trunname);

    }


   


    private void FixedUpdate()
    {
        // Adjust the rigidbodies position and orientation in FixedUpdate.
        Move();
        Turn();
    }


    private void Move()
    {
       // transform.forward = new Vector3(1f, 0f, 0f);
        transform.GetComponent<Rigidbody>().velocity = Vector3.zero; 
       // transform.GetComponent<Rigidbody>().
      //  navy.isStopped = true; 
        for (int i = 0; i < 6; i++)
        {   
            WRotation W;
            W = wheelsLeft[i].GetComponent<WRotation>();
            W.direction = 1f;
            W.isMoveing = !(Mathf.Abs(move_input) < 0.1f && Mathf.Abs(turn_input) < 0.1f);
            W = wheelsRight[i].GetComponent<WRotation>();
            W.direction = 1f;
            W.isMoveing = !(Mathf.Abs(move_input) < 0.1f && Mathf.Abs(turn_input) < 0.1f);

        }
        
        Vector3 movement = transform.forward * move_input * speed * Time.deltaTime;
      
        rg.MovePosition(transform.position + movement); 
        
    }


    private void Turn()
    {   
        for(int i = 0 ; i<6; i++)
        {
            WRotation W,Wr;
            W = wheelsLeft[i].GetComponent<WRotation>();
            Wr = wheelsRight[i].GetComponent<WRotation>();
            if (turn_input > 0)
            {
                Wr.direction = -1f; 
                W.direction = 1f;
            }
            W.isMoveing = !(Mathf.Abs(move_input) < 0.1f && Mathf.Abs(turn_input) < 0.1f);
            Wr.isMoveing = !(Mathf.Abs(move_input) < 0.1f && Mathf.Abs(turn_input) < 0.1f);
           // Wr = wheelsRight[i].GetComponent<WRotation>();
            if (move_input < 0)
            {
                Wr.direction = 1f; 
                W.direction = -1f;
            }
            W.isMoveing = !(Mathf.Abs(move_input) < 0.1f && Mathf.Abs(turn_input) < 0.1f);
            Wr.isMoveing = !(Mathf.Abs(move_input) < 0.1f && Mathf.Abs(turn_input) < 0.1f);

        }
       
        float turn = turn_input * TurnSpeed * Time.deltaTime;
        
     
        Quaternion turnRotation = Quaternion.Euler(0f, turn,0f);

        rg.MoveRotation(rg.rotation * turnRotation);
    }

    private GameObject GetChildWithName(GameObject obj, string name)
    {
        Transform trans = obj.transform;
        Transform childTrans = trans.Find(name);
        if (childTrans != null)
        {
            return childTrans.gameObject;
        }
        else
        {
            return null;
        }
    }
    private void Getwheels(GameObject[] wheels, string name, string side)
    {
     
        for (int i = 0; i < 6; i++)
        {
            Transform childTrans = transform.Find(name +i);
      
            if (childTrans != null)
            {

                wheels[i] = childTrans.gameObject;
            }
            
        }
    }


}
