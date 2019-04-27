using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noisemaker : MonoBehaviour
{
    public float volume = 0;
    public float decayPerFrameDraw = 0.016f;

    // Update is called once per frame
    void Update()
    {
        // Every frame our noise gets less, until it hits zero
        if (volume > 0)
        {
            volume -= decayPerFrameDraw;
        }
    }
}
