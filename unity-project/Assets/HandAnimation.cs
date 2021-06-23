using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAnimation : MonoBehaviour
{

    PlayerMovement movement;	//Reference to the PlayerMovement script component

    public Transform handPosHanging;
    public Transform lefthandPos;
    public Transform rightHandPos;
    public Transform leftgunpos;
    public Transform rightgunpos;

    // Start is called before the first frame update
    void Start()
    {
        Transform parent = gameObject.transform;

        movement = parent.GetComponent<PlayerMovement>();
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
