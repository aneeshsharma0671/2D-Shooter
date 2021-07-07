using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLifeBehaviour : MonoBehaviour
{
    public string EnemyName;
    public int Health;
    public GameObject CorpseOBJ;
    public GameObject DeathEffect;
    public GameObject HitEffect;

    public void TakeDamage(int damage)
    {
        Health -= damage;
        Debug.Log("got damage");
    }

    private void Update()
    {
        if(Health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        //spawn death effect
        //spawn corpse
        //destroy Enemy
        DestroyEnemy();
    }

    public void DestroyEnemy()
    {
        // call any special method on destroy
        Destroy(gameObject);
    }

}
