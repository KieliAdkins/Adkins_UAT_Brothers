using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Declaring our variables
    public static GameManager instance;
    public static Score score;
    public static PlayerController playerController;
    public static PawnAlien pawnAlien;

    public GameObject player; 

    // Checkpoint
    public GameObject currentCheckpoint;

    // Start function
    private void Start()
    {
        // Setting this as the instance
        instance = this;
    }

    // Respawning the player
    public void RespawnPlayer()
    {
        // Looking for checkpoint position
        player.transform.position = currentCheckpoint.transform.position;
    }

   
}
