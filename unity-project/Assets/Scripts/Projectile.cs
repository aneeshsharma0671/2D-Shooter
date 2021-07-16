using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public int projectileDamage;
    private Rigidbody2D rb;
    public GameObject hitEffectGFX;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer != 9)
        {
            if(collision.gameObject.GetComponentInParent<EnemyLifeBehaviour>() != null)
            {
                collision.gameObject.GetComponentInParent<EnemyLifeBehaviour>().TakeDamage(projectileDamage);
            }
            GameObject hitGFX = Instantiate(hitEffectGFX, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(hitGFX, 0.5f);
            Destroy(gameObject);
        }

      
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * speed, ForceMode2D.Impulse);
        Invoke("DestroyProjectile", lifetime);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
