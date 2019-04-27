using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPawn : Pawn
{

    // Use this for initialization
    public override void Start()
    {
        // Call the base Pawn class Start
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        // Call the base Pawn class Update
        base.Update();
        //tf.transform.Rotate(0, 0, -Time.deltaTime * rotationSpeed);
    }

    public override void MoveForward()
    {
        tf.transform.Translate(Time.deltaTime * speed, 0, 0);
    }

    public override void MoveBackward()
    {
        tf.transform.Translate(-Time.deltaTime * speed, 0, 0);
    }

    public override void RotateLeft()
    {
        tf.transform.Rotate(0, 0, Time.deltaTime * rotationSpeed);
    }

    public override void RotateRight()
    {
        tf.transform.Rotate(0, 0, -Time.deltaTime * rotationSpeed);
    }
}
