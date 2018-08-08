using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public AudioClip hit;
    public int healthHit; 
    protected Vector3 velocity;
    private Transform tf;
    public float distance;
    public float moveSpeed;
    Vector3 originalPosition;
    bool isGoingLeft = false;
    public float distFromStart;
    private SpriteRenderer sr;
    private Animator an; 

    public void Start()
    {
        // The beginning position of the enemy
        originalPosition = gameObject.transform.position;

        // Capturing the transform
        tf = GetComponent<Transform>();

        // Capturing the sprite renderer
        sr = GetComponent<SpriteRenderer>();

        // Capturing the animator
        an = GetComponent<Animator>(); 

        // Setting the velocity
        velocity = new Vector3(moveSpeed, 0, 0);

        // Getting the translate
        tf.Translate(velocity.x * Time.deltaTime, 0, 0);
    }

    void Update()
    {
        // Setting the distance from start
        distFromStart = transform.position.x - originalPosition.x;

        // If the enemy is
        if (isGoingLeft)
        {
            // Playing the animation
            an.Play("BeeMove");

            // If gone too far, switch direction
            if (distFromStart < -distance)
                SwitchDirection();

            // Translating the enemy
            tf.Translate(-velocity.x * Time.deltaTime, 0, 0);
        }

        else
        {
            // Playing the animation
            an.Play("BeeMove");

            // If gone too far, switch direction
            if (distFromStart > distance)
                SwitchDirection();

            // Translating the enemy
            tf.Translate(velocity.x * Time.deltaTime, 0, 0);
        }
    }

    // Switching direction
    void SwitchDirection()
    {
        // Changing the movement direction
        isGoingLeft = !isGoingLeft;

        sr.flipX = !sr.flipX;

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
             PlayerHealth.pHealth.currentHealth -= healthHit;

            AudioSource.PlayClipAtPoint(hit, gameObject.transform.position);
        }
    }
}
