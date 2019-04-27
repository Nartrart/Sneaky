using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Abstract Controller class - no implementation - only classes that derive from it have logic
public abstract class Controller : MonoBehaviour
{
    // The helpless pawn which is controlled!
    public Pawn pawn;

    // virtual = the method can be redefined by a derived class
    public virtual void Start()
    {
        pawn = GetComponent<Pawn>();
    }
}
