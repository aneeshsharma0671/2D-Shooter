using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackShoot : EnemyAttack
{
    public GameObject projectile;
    public Transform shoot_Point;

    public override void DoTheAttack(Transform player)
    {
        Quaternion newRot = new Quaternion();
        Vector3 diff = player.transform.position - transform.position;
        float angle = Mathf.Atan2(diff.y, diff.x);
        newRot = Quaternion.Euler(0f, 0f, angle * Mathf.Rad2Deg);

        Debug.Log("Attack");
       // Instantiate(projectile, shoot_Point.position, newRot);

        base.DoTheAttack(player);
    }
}
