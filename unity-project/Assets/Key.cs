using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    int playerLayer;

    private void Start()
    {
        playerLayer = LayerMask.NameToLayer("Player");
        GameManager.RegisterKey(this);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer != playerLayer)
        {
            return;
        }

        GameManager.PlayerGrabbedKey(this);
        gameObject.SetActive(false);
    }
}
