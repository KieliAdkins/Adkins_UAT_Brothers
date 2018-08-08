using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnAlien : Pawn {

    // Declaring our variables
    public Transform tf;
    private Rigidbody2D rb;
    private static Animator an;
    private SpriteRenderer sr;

    // Player information
    public float moveSpeed = 0.125f;
    public float jumpHeight;
    public float jumpForce; 
    public bool alienMove = false;
    public int jumpNumber; 

    // Finding if the player is on the ground
    public bool isGrounded = false;
    public float groundedDistance;

    public GameObject mCamera;


    // Use this for initialization
    void Start()
    {
        tf = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        an = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
       // Calling the check for ground function
       CheckForGrounded();

       // Move function
       Move();

        if (alienMove == true)
        {
            /// Playing the walk animation
            an.Play("Walk");
        }

        else if (alienMove == false)
        {
            an.Play("Idle");
        }

    }

   // Move function
    public override void Move()
    {
        // Moving the character right
        if (Input.GetKey(KeyCode.RightArrow))
        {
            // Moving the character's transform
            tf.position = tf.position + (Vector3.right * moveSpeed);

            // Setting the boolean to true for movement
            alienMove = true;

            // Flipping the character
            sr.flipX = false;
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            alienMove = false;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // Moving the character's transform
            tf.position = tf.position + (-Vector3.right * moveSpeed);

            // Flipping the character
            sr.flipX = true;

            // Setting the boolean to true for movement
            alienMove = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            alienMove = false; 
        }

        // If we are on the ground allow player to jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            // Adding the jump force
            rb.AddForce(Vector2.up * jumpForce);

            // Beginning the jump animations
            an.Play("Jump");
        }

        // If we are on the ground allow player to jump
        if (Input.GetKeyDown(KeyCode.Space) && jumpNumber > 0 && isGrounded == false)
        {
            // Subtracting from the jump number
            jumpNumber -= 1;

            // Adding the jump force
            rb.AddForce(Vector2.up * jumpForce);

            // Beginning the jump animations
            an.Play("Jump");

        } 

    }

    // Checking if the pawn is on the ground
    public override void CheckForGrounded()
    {
        // Variable to hold our about raycast hit
        RaycastHit2D hitInfo;

        // Casting our raycast
        hitInfo = Physics2D.Raycast(tf.position, Vector2.down, groundedDistance);

        //Debug.DrawLine(tf.position, tf.position + (Vector3.down * groundedDistance));

        // Checking if we hit "ground"
        if (hitInfo.collider != null)
        {
            // if it is set our variable
            if (hitInfo.collider.gameObject.tag == "Ground")
            {
                isGrounded = true;
            }

            // else set variable false
            else
            {
                isGrounded = false;
            }
        }

        // If nothing is hit
        else
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Checkpoint")
        {
            Destroy(collision.gameObject);
        }
    }
  
}
