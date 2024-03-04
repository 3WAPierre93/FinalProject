using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RespawnController : MonoBehaviour
{
    // static RespawnController Instance;

    public Transform respawnPoint;
    public GameObject Player;
    private void Awake()
    {
       // Instance = this;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool isPlayer = collision.attachedRigidbody.gameObject.CompareTag("Player");
         if (isPlayer)
         {   
            Player.transform.position = respawnPoint.position;
         }
    }
}
