using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementBehaviour : MonoBehaviour
{
    public float moveSpeed = 5;
    protected Transform playerInRange;
    protected Rigidbody2D rbToUse;
    public bool canMove = false;
    public bool stopped = false;
    public bool noflipping = false;
    public bool startflipped = false;
    public bool noCombatMovment = false;

    private void Start()
    {
        rbToUse = GetComponent<Rigidbody2D>();
    }

    void PlayerInRange(Transform coll)
    {
        playerInRange = coll;
    }    
    void PlayerInRangeNothing()
    {
        playerInRange = null;
    }

    private void FixedUpdate()
    {
        if (stopped)
            return;

        if(canMove)
        {
            if (playerInRange && !noCombatMovment)
            {
                CombatMovement();
            }
  
            else
                NormalMovement();
        }
    }

    public virtual void NormalMovement()
    {

    }

    public virtual void CombatMovement()
    {
        if(!noflipping)
        {
            Flipping();
        }
    }

    void Flipping()
    {
        if (playerInRange)
        {
            float dir = playerInRange.transform.position.x - rbToUse.position.x;
            if(startflipped)
            {
                if(dir>0)
                {
                    rbToUse.transform.rotation = Quaternion.Euler(0, 180, rbToUse.transform.eulerAngles.z);
                }
                else
                {
                    rbToUse.transform.rotation = Quaternion.Euler(0, 0, rbToUse.transform.eulerAngles.z);
                }
            }
            else
            {
                if(dir > 0)
                {
                    rbToUse.transform.rotation = Quaternion.Euler(0, 0, rbToUse.transform.eulerAngles.z);
                }
                else
                {
                    rbToUse.transform.rotation = Quaternion.Euler(0, 180, rbToUse.transform.eulerAngles.z);
                }
            }
            
        }


    }
}
