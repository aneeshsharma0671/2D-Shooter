using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float attackCD = 1;
    public bool isinCD = false;
    public float attackDuration = 1;
    public bool readyToAttack = true;
    public string animtrigger = "BasicAttack";
    public bool hasAnim = true;
    public float attackRangeMax = 2;
    public float attackRangeMin = 0;
    public bool alwaysInRange = false;
    public bool startWithCD = false;

    public bool showGizmos = true;
    public Color testingColor;


    public virtual void DoTheAttack(Transform player)
    {
        if (attackCD > 0)
            StartCoroutine(AttackCD(attackCD));
    }

    private IEnumerator AttackCD(float waitTime)
    {
        float CD = waitTime;
        while (CD > 0)
        {
            readyToAttack = false;
            CD -= Time.fixedDeltaTime;
            yield return null;
        }
        readyToAttack = true;
    }
    public bool CanDoTheAttack(Vector2 playerpos)
    {
        if (!readyToAttack)
            return false;
        if (alwaysInRange)
            return true;

        float dist = Vector2.Distance(transform.position, playerpos);
        if (IsInDistance(dist))
            return true;
        else
            return false;
    }

    bool IsInDistance(float dist)
    {
        if (dist >= attackRangeMin && dist < attackRangeMax)
            return true;
        else
            return false;
    }

    private void OnDrawGizmos()
    {
        if (!showGizmos)
            return;
        Gizmos.color = testingColor;
        Gizmos.DrawWireSphere(transform.position, attackRangeMax);
    }

}
