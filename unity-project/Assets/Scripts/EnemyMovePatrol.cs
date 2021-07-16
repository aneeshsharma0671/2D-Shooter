using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovePatrol : EnemyMovementBehaviour
{
    public LayerMask layer;
    public Vector3 checkoffset;
    private bool facingRight = true;
    public float GroundInfoCheck = 4;
    public float WallInfoCheck = 4;

    public override void NormalMovement()
    {
        Vector2 v = rbToUse.transform.right * moveSpeed;
        Vector2 newpos = rbToUse.position + (v * Time.deltaTime);
        rbToUse.MovePosition(newpos);
        if(ShouldFlip())
        {
            flip();
        }
    }

    public override void CombatMovement()
    {
        rbToUse.velocity = new Vector2(moveSpeed * rbToUse.transform.right.x, rbToUse.velocity.y);

        if (playerInRange.transform.position.x > rbToUse.position.x)
            rbToUse.transform.rotation = Quaternion.Euler(0, 0, 0);
        else if (playerInRange.transform.position.x < rbToUse.position.x)
            rbToUse.transform.rotation = Quaternion.Euler(0, 180, 0);
    }

    bool ShouldFlip()
    {
        Vector3 checkpos = rbToUse.position;
        RaycastHit2D groundinfo = Physics2D.Raycast(checkpos + rbToUse.transform.right + checkoffset, -rbToUse.transform.up, GroundInfoCheck, layer);
        Debug.DrawRay(checkpos + rbToUse.transform.right + checkoffset, -rbToUse.transform.up * GroundInfoCheck,Color.blue);

        RaycastHit2D wallInfo = Physics2D.Raycast(checkpos, rbToUse.transform.right, WallInfoCheck, layer);
        Debug.DrawRay(checkpos, rbToUse.transform.right * WallInfoCheck, Color.blue);

        if (!groundinfo || wallInfo)
            return true;
        else
            return false;
    }
    void flip()
    {
        facingRight = !facingRight;
        rbToUse.transform.Rotate(0f, 180f, 0f);
    }
}
