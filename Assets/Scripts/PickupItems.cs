using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItems : MonoBehaviour {

    // Declaring our variables
    public GameObject item;
    public AudioClip hit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Playing audio source
            AudioSource.PlayClipAtPoint(hit, item.transform.position);

            // Adding a score to the player Score
            GameManager.score.playerScore += 500;
        }  
    }

}
