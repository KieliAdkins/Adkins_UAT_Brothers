using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {

    //public GameManager GameManager;

    //private void Start()
    //{
    //    GameManager = FindObjectOfType<GameManager>();
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Begin the respawn
            GameManager.instance.RespawnPlayer();
        }
    }
}
