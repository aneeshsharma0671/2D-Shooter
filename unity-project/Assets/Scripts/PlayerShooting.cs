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

    PlayerInput input;

    private float timeBtwShoots = 0f;
    public float starttimeBtwShoots = 0.1f;

    private Quaternion bullet_rotation;

    private void Start()
    {
        input = GetComponent<PlayerInput>();
    }

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
        Vector2 difference;
        // Weopon rotation
        if (player.direction == 1)
        {
            difference = input.mousePosition;
        }
        else
        {
            difference = new Vector2(0f,0f) - input.mousePosition;
        }

        float rotz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        if (-90 <= rotz && rotz <= 90)
        {
            weapon_slot.rotation = Quaternion.Euler(0f, 0f, rotz + offset);
        }
        else
        {
            player.FlipCharacterDirection();
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
           // Debug.Log("time");
            if (input.firePressed)
            {
              //  Debug.Log("fire");
                

                Instantiate(projectile,position,rotation);
                rotation *= Quaternion.Euler(0f, 0f, 15f);
                Instantiate(projectile,position,rotation);
                rotation *= Quaternion.Euler(0f, 0f, -30f);
                Instantiate(projectile, position, rotation);
                timeBtwShoots = starttimeBtwShoots;
            }
        }
        else
        {
            timeBtwShoots -= Time.deltaTime;
        }
    }

}
