using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    public Transform target;

    public float speed = 200f;
    public float nextWayPointDis = 3f;

    public Transform enemyGFX;

    Path path;
    int currentWayPoint = 0;
    bool reachedEndOfPath = false;
    int enemyDirection = 1;

    Seeker seeker;
    Rigidbody2D rb;

    private void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

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
        if(path == null)
            return;
        if(currentWayPoint >= path.vectorPath.Count)
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

        if(distance < nextWayPointDis)
        {
            currentWayPoint++;
        }

        if (target.position.x-rb.position.x > 0f)
        {
            enemyDirection = 1;
        }
        else if (target.position.x - rb.position.x < 0f)
        {
            enemyDirection = -1;
        }

       
        Debug.Log(enemyDirection);
    }

    private void Update()
    {
        enemyGFX.localScale = new Vector3(enemyDirection, 1f, 1f);
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

}
