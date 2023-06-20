using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System; 

public class EnemyAII : MonoBehaviour
{

    public EnemyShoot shoot; 
    public NavMeshAgent navy;
    public Transform[] patrolPoints;
    public int enemySpeed;
    public LayerMask Player;
    public LayerMask toCollect; 
    public float viewRadius = 60f;
    public GameFlow gameFlow;
    bool ispatrol; 
    private int currentPatrol;
 
  

    private void Awake()
    {
        gameFlow.RegisterTank();
        ispatrol = false; 
    }

    // Start is called before the first frame update
    void Start()
    {
        navy.speed = enemySpeed; 
        currentPatrol = 0;

        
            
    }

    // Update is called once per frame
    void Update()
    {
      
        IsPlayerInRange(); 
        Patrol();
        
    }
    void Patrol()
    {

        ispatrol = true; 
        if (IsFinisehd())
        {   
            currentPatrol++;
            currentPatrol = currentPatrol % patrolPoints.Length;
        
            navy.SetDestination(patrolPoints[currentPatrol].position);
        }
    }

    void IsPlayerInRange()
    {
        ispatrol = false; 
        Collider[] playerInRange = Physics.OverlapSphere(transform.position, viewRadius, Player);
        if (playerInRange.Length >0)
        {
           Transform player =playerInRange[0].gameObject.transform;
            Vector3 dirToPlayer = (player.position - transform.position).normalized;
            if(Math.Abs(Vector3.Distance (player.position, transform.position))< 30f)
            {
                 navy.isStopped = true; 
                 transform.forward = dirToPlayer;
                 if (shoot.ammo_fireMissiles > 0) { shoot.ShootMissile(); }
                 else if (shoot.ammo_projectiles > 0) { shoot.ShootProjectile(); }
            }
            else
            {
                navy.isStopped = false; 
                navy.SetDestination(player.position);
            }
            //transform.forward = dirToPlayer;
           // navy.SetDestination(transform.position);
          
               // if (shoot.ammo_fireMissiles > 0) { shoot.ShootMissile(); }
               // else if (shoot.ammo_projectiles > 0) { shoot.ShootProjectile(); }
           
            

        }
       

      

    }

    bool IsFinisehd()
    {
        if (!navy.pathPending)
        {
            if (navy.remainingDistance <= navy.stoppingDistance)
            {
                if (!navy.hasPath || navy.velocity.sqrMagnitude == 0f)
                {
                    return true; 
                }
            }
            return false;
        }
        return false; 
    }
}
