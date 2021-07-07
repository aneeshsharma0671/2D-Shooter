using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public enum batstate
{
    idle,
    attack
}

public class EnemyAI : MonoBehaviour
{
    public batstate state;
    public Transform target;
    int playerlayer;
    public float speed = 200f;
    public float nextWayPointDis = 3f;
    public int maxColliders = 10;
    public float chaseDistance;
    public float attackDistance;
    public Transform enemyGFX;

    public bool isAttacking;

 
    Path path;
    int currentWayPoint = 0;
    bool reachedEndOfPath = false;
    int enemyDirection = 1;

    Seeker seeker;
    Rigidbody2D rb;
    Transform player;
  

    private void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMovement>().gameObject.transform;
    
        InvokeRepeating("UpdatePath", 0f, 0.5f);
       

    }
    
    void UpdatePath()
    {
        if(seeker.IsDone())
            seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

   

    void OnPathComplete(Path p)
    {
        if(!p.error)
        {
            path = p;
            currentWayPoint = 0;
        }
    }

    private void FixedUpdate()
    {
     

        switch (state)
        {
            case batstate.idle:
                break;
            case batstate.attack:
                chaseTarget();
                break;
            default:
                break;
        }
        
    }

    private void Update()
    {
        surroundCheck();
        enemyGFX.localScale = new Vector3(enemyDirection, 1f, 1f);
    }

 

    void surroundCheck()
    {
        float distancefromPlayer = Vector2.Distance(player.position, transform.position);
        if(distancefromPlayer < chaseDistance)
        {
            state = batstate.attack;
        }
        else
        {
            state = batstate.idle;
        }
        float distanceforAttack = Vector2.Distance(player.position, transform.position);
        if(distanceforAttack < attackDistance)
        {
            isAttacking = true;
        }
        else
        {
            isAttacking = false;
        }

    }

    void chaseTarget()
    {
        if (path == null)
            return;
        if (currentWayPoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWayPoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWayPoint]);

        if (distance < nextWayPointDis)
        {
            currentWayPoint++;
        }

        if (target.position.x - rb.position.x > 0f)
        {
            enemyDirection = 1;
        }
        else if (target.position.x - rb.position.x < 0f)
        {
            enemyDirection = -1;
        }
    }

  

    void UpdateGFX(int direction)
    {
        if(direction >= 0)
        {
           
        }
        else if(direction <= 0)
        {
            enemyGFX.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, chaseDistance);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackDistance);
    }

}
