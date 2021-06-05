using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float lifetime;

    private void Start()
    {
        Invoke("DestroyProjectile", lifetime);
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate( new Vector3(1f,0f,0f) * speed * Time.deltaTime);
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
