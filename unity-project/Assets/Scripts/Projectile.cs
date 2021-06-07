using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float lifetime;
    private Rigidbody2D rb;
    public LayerMask playerlayer;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer != 9)
        {
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
