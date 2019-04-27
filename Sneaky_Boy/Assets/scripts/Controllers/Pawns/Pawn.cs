using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// base class for the pawn
public abstract class Pawn : MonoBehaviour
{
    public Transform tf;

    public Vector3 homePosition;

    public float speed = 10.0f;
    public float rotationSpeed = 180.0f;
    public Sprite sprite;

    public virtual void Start()
    {
        tf = GetComponent<Transform>();
        GetComponent<SpriteRenderer>().sprite = sprite;

        homePosition = tf.position;
    }

    public virtual void Update()
    {
    }

    public virtual void MoveForward()
    {

    }

    public virtual void MoveBackward()
    {

    }

    public virtual void RotateLeft()
    {

    }

    public virtual void RotateRight()
    {
    }

    public virtual void GoHome()
    {

    }

    public virtual void Roll()
    {

    }
}
