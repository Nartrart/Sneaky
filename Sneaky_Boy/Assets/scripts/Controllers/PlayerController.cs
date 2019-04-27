using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Inherit from Controller
public class PlayerController : Controller
{
    // Use this for initialization
    public override void Start()
    {
        // Call the Controller base class Start
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        // The player controller gets input from the keyboard and then moves the pawn.
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            pawn.MoveForward();
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            pawn.MoveBackward();
        }

        // Only the person will rotate, but always handle the inpyut
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            pawn.RotateLeft();
        }

        // Only the person pawn will rotate, but always handle the inpyut
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            pawn.RotateRight();

        }

        // All pawns can go home
        if (Input.GetKey(KeyCode.H) || Input.GetKey(KeyCode.Space))
        {
            pawn.GoHome();
        }

        // Only the dog pawn will roll, but always handle the inpyut
        if (Input.GetKey(KeyCode.R))
        {
            pawn.Roll();
        }
    }
}