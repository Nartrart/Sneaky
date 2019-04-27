
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{
    // Components
    private AISenses senses;

    // FSM
    public enum AIStates
    {
        Idle,
        Chase,
        LookAround,
        GoHome,
        StartAlert, // Not used yet....
        EndAlert    // Not used yet....
    }
    public Vector3 homePoint;
    public Vector3 goalPoint;
    public AIStates currentState;
    public float giveUpChaseDistance;
    public float closeEnough;

    public float moveSpeed = 1;
    public float turnSpeed = 1;
    Transform tf;

    // Use this for initialization
    void Start()
    {
        // Store my senses component
        senses = GetComponent<AISenses>();

        tf = GetComponent<Transform>();

        // Save my home point
        homePoint = tf.position;
    }

    // Update is called once per frame
    void Update()
    {
        // AI States are based on enum value
        switch (currentState)
        {
            case AIStates.Idle:
                // Do Work
                Idle();
                // Check for Transitions
                if (senses.CanHear(GameManager.instance.player.gameObject))
                {
                    currentState = AIStates.LookAround;
                }
                if (senses.CanSee(GameManager.instance.player.gameObject))
                {
                    currentState = AIStates.Chase;
                }
                break;

            case AIStates.Chase:
                // Do Work
                Chase();
                // Check for Transitions
                if (!senses.CanSee(GameManager.instance.player.gameObject))
                {
                    currentState = AIStates.LookAround;
                }
                if (Vector3.Distance(tf.position, GameManager.instance.player.tf.position) > giveUpChaseDistance)
                {
                    currentState = AIStates.GoHome;
                }
                break;

            case AIStates.LookAround:
                // Do Work
                LookAround();
                // Check for Transitions
                if (senses.CanSee(GameManager.instance.player.gameObject))
                {
                    currentState = AIStates.Chase;
                }
                else if (Vector3.Distance(tf.position, GameManager.instance.player.tf.position) > giveUpChaseDistance)
                {
                    currentState = AIStates.GoHome;
                }
                else if (!senses.CanHear(GameManager.instance.player.gameObject))
                {
                    currentState = AIStates.GoHome;
                }
                break;

            case AIStates.GoHome:
                // Do Work
                GoHome();
                // Check for Transitions
                if (senses.CanHear(GameManager.instance.player.gameObject))
                {
                    currentState = AIStates.LookAround;
                }
                if (senses.CanSee(GameManager.instance.player.gameObject))
                {
                    currentState = AIStates.Chase;
                }
                if (Vector3.Distance(tf.position, homePoint) <= closeEnough)
                {
                    currentState = AIStates.Idle;
                }
                break;
        }
    }

    public void Idle()
    {
        // Do Nothing
    }

    public void Chase()
    {
        goalPoint = GameManager.instance.player.tf.position;
        MoveTowards(goalPoint);
    }

    public void GoHome()
    {
        goalPoint = homePoint;
        MoveTowards(goalPoint);
    }

    public void LookAround()
    {
        Turn(true);
    }

    public void MoveTowards(Vector3 target)
    {
        if (Vector3.Distance(tf.position, target) > closeEnough)
        {
            // Look at target
            Vector3 vectorToTarget = target - tf.position;
            tf.right = vectorToTarget;

            // Move Forward
            Move(tf.right);
        }
    }

    public void Move(Vector3 direction)
    {
        // Move in the direction passed in, at speed "moveSpeed"
        tf.position += (direction.normalized * moveSpeed * Time.deltaTime);
    }

    public void Turn(bool isTurnClockwise)
    {
        // Rotate based on turnSpeed and direction we are turning
        if (isTurnClockwise)
        {
            tf.Rotate(0, 0, turnSpeed * Time.deltaTime);
        }
        else
        {
            tf.Rotate(0, 0, -turnSpeed * Time.deltaTime);
        }
    }
}