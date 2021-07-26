using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackBehaviour : MonoBehaviour
{
    public Transform attackContainer;
    public List<EnemyAttack> attacks;
    EnemyAttack attackToExecute;
    private Transform player;
    

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
    }
    private void Update()
    {
        Attack();
    }

    EnemyAttack AttackToUse()
    {
        List<EnemyAttack> availableAttack = new List<EnemyAttack>();
        
        foreach (EnemyAttack item in attacks)
        {
            if(item.CanDoTheAttack(player.position))
            {
                availableAttack.Add(item);
            }
        }
        if (availableAttack.Count != 0)
            return availableAttack[0];
        else
            return null;
    }

    void Attack()
    {
        EnemyAttack attack = AttackToUse();
        if (!attack)
            return;

        attackToExecute = attack;
        if (!attackToExecute.hasAnim)
            ExecuteAttack();

        // here animatoin attack

        // here ckeck attackDuration
        
    }

    public void ExecuteAttack()
    {
        attackToExecute.DoTheAttack(player);
    }

}
