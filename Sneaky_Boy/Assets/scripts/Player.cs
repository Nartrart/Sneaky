using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform tf;
    public Noisemaker noisemaker;

    public float moveSpeed = 5;
    public float turnSpeed = 5;

    public float moveVolume = 5;
    public float turnVolume = 5;

    // Keys
    public KeyCode forwardKey = KeyCode.W;
    public KeyCode turnLeftKey = KeyCode.A;
    public KeyCode backwardKey = KeyCode.S;
    public KeyCode turnRightKey = KeyCode.D;
    public KeyCode strafeLeftKey = KeyCode.Q;
    public KeyCode strafeRightKey = KeyCode.E;

    // Use this for initialization
    void Start()
    {
        tf = gameObject.transform;

        // Load noisemaker
        noisemaker = GetComponent<Noisemaker>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(forwardKey))
        {
            Move(tf.right);
        }

        if (Input.GetKey(strafeRightKey))
        {
            Move(-tf.up);
        }

        if (Input.GetKey(backwardKey))
        {
            Move(-tf.right);
        }

        if (Input.GetKey(strafeLeftKey))
        {
            Move(tf.up);
        }

        if (Input.GetKey(turnLeftKey))
        {
            Turn(true);
        }

        if (Input.GetKey(turnRightKey))
        {
            Turn(false);
        }
    }

    public void Move(Vector3 direction)
    {
        // Move in the direction passed in, at speed "moveSpeed"
        tf.position += (direction.normalized * moveSpeed);

        // Moving makes noise! Change volume to whichever is more -- current volume or the move volume
        if (noisemaker != null)
        {
            noisemaker.volume = Mathf.Max(noisemaker.volume, moveVolume);
        }
    }

    public void Turn(bool isTurnClockwise)
    {
        // Rotate based on turnSpeed and direction we are turning
        if (isTurnClockwise)
        {
            tf.Rotate(0, 0, turnSpeed);

            // Turning makes noise! Change volume to whichever is more -- current volume or the turn volume
            if (noisemaker != null)
            {
                noisemaker.volume = Mathf.Max(noisemaker.volume, turnVolume);
            }
        }
        else
        {
            tf.Rotate(0, 0, -turnSpeed);
            // Turning makes noise! Change volume to whichever is more -- current volume or the turn volume
            if (noisemaker != null)
            {
                noisemaker.volume = Mathf.Max(noisemaker.volume, turnVolume);
            }
        }
    }
}