using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLifeBehaviour : MonoBehaviour
{
    public string EnemyName;
    public int Health;
    public bool hasKey;
    public GameObject CorpseOBJ;
    public GameObject DeathEffect;
    public GameObject HitEffect;

    GameObject key;

    private void Start()
    {
        if(hasKey)
        {
            key = gameObject.GetComponentInChildren<Key>().gameObject;
            key.SetActive(false);
        }
    }
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
        if(hasKey)
        {
            key.transform.parent = null;
            key.SetActive(true);
            key.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            key.GetComponent<Rigidbody2D>().AddForce(Vector2.up*10f);
        }
        DestroyEnemy();
    }

    public void DestroyEnemy()
    {
        // call any special method on destroy
        Destroy(gameObject);
    }

}
