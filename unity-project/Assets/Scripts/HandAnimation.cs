using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAnimation : MonoBehaviour
{

    PlayerMovement movement;	//Reference to the PlayerMovement script component

    public GameObject weapon_slot;

    public Transform handPosHanging;
    public Transform lefthandPos;
    public Transform rightHandPos;
    private Transform leftgunpos;
    private Transform rightgunpos;

    // Start is called before the first frame update
    void Start()
    {
        Transform parent = gameObject.transform;

        movement = parent.GetComponent<PlayerMovement>();

        leftgunpos = weapon_slot.GetComponentInChildren<Weapon>().leftHandpos;
        rightgunpos = weapon_slot.GetComponentInChildren<Weapon>().rightHandpos;
    }

    // Update is called once per frame
    void Update()
    {
        if(movement.isHanging)
        {
            lefthandPos.position = handPosHanging.position;
            rightHandPos.position = handPosHanging.position;
        }
        else
        {
            lefthandPos.position = leftgunpos.position;
            rightHandPos.position = rightgunpos.position;
        }
 

    }
}
