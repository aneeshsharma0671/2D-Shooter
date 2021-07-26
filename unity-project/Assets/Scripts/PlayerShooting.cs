using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public float offset;
    public float zmin = -90f;
    public float zmax = 90f;

    public GameObject headBone;
    public float headClamp;
    public float gunClamp;

    public WeaponInfoScriptableObject weaponInfo;
    
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
        //if (-headClamp <= weapon_slot.rotation.z && weapon_slot.rotation.z <= headClamp)
        setHeadRotation();
       
            
        if(shoot_point == null)
        {
            shoot_point = weapon_slot.GetComponentInChildren<Weapon>().shoot_point;
        }
        shoot(weaponInfo.weapons[GameInfo.weaponindex].bulletPrefab, shoot_point.position, bullet_rotation, weaponInfo.weapons[GameInfo.weaponindex].weaponType , weaponInfo.weapons[GameInfo.weaponindex].shootAudio);
    }

    void setHeadRotation()
    {
       
       headBone.transform.rotation = weapon_slot.rotation;
        

        if (player.direction == 1)
        {
            headBone.transform.rotation *= Quaternion.Euler(0f, 0f, 90f);
        }
        else
        {
            headBone.transform.rotation *= Quaternion.Euler(0f, 0f, -90f);
        }
       
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

        if (-gunClamp <= rotz && rotz <= gunClamp)
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

    void shoot(GameObject bullet_prefab,Vector3 position , Quaternion rotation ,weaponTypes weapondata , AudioClip audio)
    {
        if (timeBtwShoots <= 0)
        {
           // Debug.Log("time");
            if (input.firePressed)
            {
                AudioManager.PlayShootAudio(audio);
                //  Debug.Log("fire");
                switch (weapondata)
                {
                    case weaponTypes.pistol:
                        Instantiate(bullet_prefab, position, rotation);
                        break;
                    case weaponTypes.rifle:
                        break;
                    case weaponTypes.shotgun:
                        Instantiate(bullet_prefab, position, rotation);
                        rotation *= Quaternion.Euler(0f, 0f, 15f);
                        Instantiate(bullet_prefab, position, rotation);
                        rotation *= Quaternion.Euler(0f, 0f, -30f);
                        Instantiate(bullet_prefab, position, rotation);
                       
                        break;
                    default:
                        break;
                }
                timeBtwShoots = starttimeBtwShoots;
            }
        }
        else
        {
            timeBtwShoots -= Time.deltaTime;
        }
    }

}
