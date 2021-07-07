using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionRange : MonoBehaviour
{
    public float visionRange = 10;
    public bool inRange = false;

    private void Update()
    {

        Collider2D coll = Physics2D.OverlapCircle(transform.position, visionRange, LayerMask.GetMask("Player"));
        if (!coll)
        {
            inRange = false;
            transform.parent.BroadcastMessage("PlayerInRangeNothing",SendMessageOptions.DontRequireReceiver);
            return;
        }
            

        Vector3 endpos = coll.transform.position;
        Vector3 dir = (endpos - transform.position);
        float dis = Vector2.Distance(transform.position, endpos);

        //checkif player behind wall
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir.normalized, dis, LayerMask.GetMask("Platforms"));
        if (hit)
        {
            inRange = false;
            transform.parent.BroadcastMessage("PlayerInRangeNothing", SendMessageOptions.DontRequireReceiver);
            return;
        }

        transform.parent.BroadcastMessage("PlayerInRange", coll.transform, SendMessageOptions.DontRequireReceiver);
        inRange = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, visionRange);
    }

}
