using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public float offset;
    public float zmin = -90f;
    public float zmax = 90f;

    private GameObject projectile;
    private Transform shoot_point;
    public PlayerMovement player;
    public Transform weapon_slot;

    private float timeBtwShoots;
    public float starttimeBtwShoots;

    private Quaternion bullet_rotation;

    void Update()
    {
        setrotation();
        if(shoot_point == null)
        {
            shoot_point = weapon_slot.GetComponentInChildren<Weapon>().shoot_point;
            projectile = weapon_slot.GetComponentInChildren<Weapon>().bulletprefab;
        }
        shoot(projectile, shoot_point.position, bullet_rotation);
    }

    void setrotation()
    {
        Vector3 difference;
        // Weopon rotation
        if (player.direction == 1)
        {
            difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - weapon_slot.position;
        }
        else
        {
            difference = -Camera.main.ScreenToWorldPoint(Input.mousePosition) + weapon_slot.position;
        }

        float rotz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        if (-90 <= rotz && rotz <= 90)
        {
            weapon_slot.rotation = Quaternion.Euler(0f, 0f, rotz + offset);
        }

        //bullet rotation
        bullet_rotation = weapon_slot.rotation;
            
        if(player.direction != 1)
        {
        if (-90 <= rotz && rotz <= 90)
        {
           bullet_rotation = Quaternion.Euler(0f, 0f, rotz + 180 + offset);
        }
        }
    }

    void shoot(GameObject bullet_prefab,Vector3 position , Quaternion rotation)
    {
        if (timeBtwShoots <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(projectile,position,rotation);
                timeBtwShoots = starttimeBtwShoots;
            }
        }
        else
        {
            starttimeBtwShoots -= Time.deltaTime;
        }
    }

}
