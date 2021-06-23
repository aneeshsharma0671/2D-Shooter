using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAnimation : MonoBehaviour
{
    public Transform lefthandPos;
    public Transform rightHandPos;
    public Transform leftgunpos;
    public Transform rightgunpos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lefthandPos.position = leftgunpos.position;
        rightHandPos.position = rightgunpos.position;

    }
}
