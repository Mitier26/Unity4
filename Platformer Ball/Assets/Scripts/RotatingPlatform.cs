using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : KinematicPlatform
{
    public float cycleRotation = 180f;

    protected override void Update()
    {
        base.Update();

        if(currentWaitTime <= 0)
        {
            transform.Rotate(0, 0, cycleRotation / cycleRunTime * cycleDirection * Time.deltaTime);
        }
    }
}
