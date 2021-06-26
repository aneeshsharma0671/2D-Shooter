using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerWeaponManager : MonoBehaviour
{
    PlayerShooting shooting;
    PlayerMovement movement;

    public List<GameObject> weapon_index;
  //  public List<GameObject> weapon_inventory;
    public GameObject weapon_slot;
    public int currentweaponindex = 0;
    public GameObject currentweapon;

    public Vector3 gunBackPosition;
    public Vector3 gunCrouchPosition;
    public Quaternion gunBackRotation;

    public Vector3 gunPosition;
    public Quaternion gunRotation;

    private void Awake()
    {
        updateweapon(GameInfo.weaponindex);
    }

    private void Start()
    {
        shooting = GetComponent<PlayerShooting>();
        movement = GetComponent<PlayerMovement>();

      

    }

    public void EnableShooting()
    {
        shooting.enabled = true;
        weapon_slot.transform.localPosition = gunPosition;
        weapon_slot.transform.localRotation = gunRotation;
    }

    public void DisableShooting()
    {
        shooting.enabled = false;
        weapon_slot.transform.localPosition = gunBackPosition;
        weapon_slot.transform.localRotation = gunBackRotation;
    
    }


    public void setCrouchGunPosition()
    {
        weapon_slot.transform.localPosition = gunCrouchPosition;
    }

    public void setStandingGunPosition()
    {
        weapon_slot.transform.localPosition = gunPosition;
    }


    void updateweapon(int weaponIndex)
    {
     //   Destroy(weapon_slot.GetComponentInChildren<Weapon>().gameObject);
        GameObject newweapon = Instantiate(weapon_index[weaponIndex], weapon_slot.transform);
    }


    /*

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<WeaponInfo>() != null)
        {
            checkinventory(collision.gameObject);
        }
    }

    private void Start()
    {
        Debug.Log(weapon_slot.GetComponentInChildren<Weapon>().gameObject);
    }

    void checkinventory(GameObject collision)
    {
        foreach (GameObject Weapon in weapon_inventory)
        {
            if (Weapon.GetComponent<Weapon>().Weaponindex == collision.GetComponent<WeaponInfo>().weaponIndex)
            {
                Destroy(collision.gameObject);
                return;
            }
        }
        weapon_inventory.Add(weapon_index[collision.GetComponent<WeaponInfo>().weaponIndex]);
        Destroy(collision.gameObject);

    }

    private void Update()
    {
       if(Input.GetKeyDown(KeyCode.Tab))
        {
            tryswapWeapon();
        } 
    }
    */



}
