using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public bool drawDebugRaycasts = true;

    public float offset;
    public float zmin = -90f;
    public float zmax = 90f;

    public GameObject projectile;
    public Transform shoot_point;
    public LayerMask Enemy;
    public PlayerMovement player;

    private float timeBtwShoots;
    public float starttimeBtwShoots;

    void Update()
    {
            Vector3 scale = new Vector3(1, 1, 1);
            transform.localScale = scale;
            Vector3 difference;

            // Weopon rotation
            if(player.direction == 1)
            {
             difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            }
            else
            {
            difference = -Camera.main.ScreenToWorldPoint(Input.mousePosition) + transform.position;
            }

            float rotz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

            if (-90 <= rotz && rotz <= 90)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, rotz + offset);
            }

            Quaternion bullet_rotation = transform.rotation;
            
            if(player.direction != 1)
            {
            if (-90 <= rotz && rotz <= 90)
            {
                bullet_rotation = Quaternion.Euler(0f, 0f, rotz + 180 + offset);
            }
            
            }
            
            if (timeBtwShoots <= 0)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    
                    Instantiate(projectile, shoot_point.position, bullet_rotation);
                    timeBtwShoots = starttimeBtwShoots;
                }
            }
            else
            {
                starttimeBtwShoots -= Time.deltaTime;
            }
    }

}
