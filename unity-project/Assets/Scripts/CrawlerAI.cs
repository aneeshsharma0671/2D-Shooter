using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public enum crawlerstate
{
    patrol,
    attack
}

public class CrawlerAI : MonoBehaviour
{
    private bool movingRight = true;
    public float distance;
    public Transform groundDetection;


    public crawlerstate state;

    public Transform target;
    public Transform waypoint1;
    public Transform waypoint2;
    private Transform currentwaypoint;

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
        state = crawlerstate.patrol;
        currentwaypoint = waypoint1;
        target = currentwaypoint;
        InvokeRepeating("UpdatePath", 0f, 0.5f);

    }

    void UpdatePath()
    {
        if (seeker.IsDone())
            seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        Debug.Log("crawler complete");
        if (!p.error)
        {
            path = p;
            currentWayPoint = 0;
        }
    }

    void changeWaypoint()
    {
        if (state == crawlerstate.patrol)
        {
            if (currentwaypoint == waypoint1)
            {
                currentwaypoint = waypoint2;
            }
            else
            {
                currentwaypoint = waypoint1;
            }
        }
    }

    private void FixedUpdate()
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


        Debug.Log(enemyDirection);
    }

    private void Update()
    {
        if(state == crawlerstate.patrol)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);

            RaycastHit2D groundinfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
            if(groundinfo.collider == false)
            {
                if(movingRight == true)
                {
                    transform.eulerAngles = new Vector3(0, -180, 0);
                    movingRight = false;
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    movingRight = true;
                }
            }


        }
        /*
        enemyGFX.localScale = new Vector3(enemyDirection, 1f, 1f);
        RaycastHit2D PlayerCheck = Physics2D.Raycast(transform.position,Vector2.right);
        if (PlayerCheck.collider.gameObject.GetType() == typeof(PlayerHealth))
        {
            state = crawlerstate.attack;
            target = GameObject.FindObjectOfType<PlayerHealth>().transform;
        }
        else
        {
            state = crawlerstate.patrol;
          //  target = currentwaypoint;
        }
        */
    }

    void UpdateGFX(int direction)
    {
        if (direction >= 0)
        {

        }
        else if (direction <= 0)
        {
            enemyGFX.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

}
