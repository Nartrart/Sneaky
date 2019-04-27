using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Inherit from Controller
public class AIController : Controller
{

    float lastMovedTime;

    public float timeToMove;

    // Use this for initialization
    public override void Start()
    {
        // Call the Controller base class Start
        base.Start();
        lastMovedTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

        // See if it's time to move the pawn
        if ((Time.time - lastMovedTime) > timeToMove)
        {
            // the AI controls the pawn using random movements
            lastMovedTime = Time.time;

            // determine random movement
            int movement = Random.Range(0, 4);

            // Move the pawn
            if (movement == 0)
            {
                pawn.MoveForward();
            }
            else if (movement == 1)
            {
                pawn.MoveBackward();
            }
            else if (movement == 2)
            {
                pawn.RotateLeft();
            }
            else if (movement == 3)
            {
                pawn.RotateRight();
            }
        }
    }
}