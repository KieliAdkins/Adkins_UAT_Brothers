using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pawn : PlayerController {

    // Declaring our variables
    public virtual void Move()
    {
        Debug.Log("Parent move"); 
    }

    public virtual void CheckForGrounded()
    {
        Debug.Log("Parent ground check");
    }
}
