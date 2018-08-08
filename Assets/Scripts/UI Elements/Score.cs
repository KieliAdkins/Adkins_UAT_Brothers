using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Score : MonoBehaviour {

    // Declaring our variables
    public static GameObject pScore; 
    public Text scoreText;
    public float playerScore;

    // Start function
    private void Start()
    {
        // Connecting the script to the GameManager
        GameManager.score = this;
    }

    // Update function
    private void Update()
    {
        // Calling the Score Text function
        SetScoreText();
    }

    // Score Text function
    void SetScoreText()
    {
        // Setting the score text to display the player's score
        scoreText.text = "Score: " + playerScore.ToString();
    }
}
