using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    float maxHealth = 100;
    public float health;
    int bulletLayer;

    public GameObject hitGFXPrefab;

    private void Start()
    {
        health = maxHealth;
        bulletLayer = LayerMask.NameToLayer("Bullet");
    }
    private void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer != bulletLayer)
        {
            return;
        }
        takeDamage(20);

    }

    void takeDamage(float damage)
    {
        health -= damage;
        Instantiate(hitGFXPrefab, transform.position, transform.rotation);
    }



}
