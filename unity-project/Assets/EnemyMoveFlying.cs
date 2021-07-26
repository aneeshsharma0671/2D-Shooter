using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveFlying : EnemyMovementBehaviour
{
    public override void NormalMovement()
    {
        rbToUse.velocity = new Vector2(0,0);
        base.NormalMovement();
    }


    public override void CombatMovement()
    {
        Vector2 dir = (Vector2)playerInRange.transform.position - rbToUse.position;
        rbToUse.velocity = moveSpeed*dir.normalized;

        if (playerInRange.transform.position.x > rbToUse.position.x)
            rbToUse.transform.rotation = Quaternion.Euler(0, 0, 0);
        else if (playerInRange.transform.position.x < rbToUse.position.x)
            rbToUse.transform.rotation = Quaternion.Euler(0, 180, 0);
      
    }
}
