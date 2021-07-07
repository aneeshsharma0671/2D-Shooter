using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatAnimation : MonoBehaviour
{
    int attackingparamID;
    Animator anim;
    EnemyAI enemy;
    void Start()
    {
        anim = GetComponent<Animator>();
        enemy = GetComponentInParent<EnemyAI>();
        attackingparamID = Animator.StringToHash("isAttacking");
    }
    private void Update()
    {
        anim.SetBool(attackingparamID, enemy.isAttacking);
    }

    public void giveDamage()
    {
        Debug.Log("damage");
    }
}
