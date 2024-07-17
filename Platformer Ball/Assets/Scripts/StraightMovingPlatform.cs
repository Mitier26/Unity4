using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightMovingPlatform : KinematicPlatform
{
    public Vector2 endPoint;
    Vector2 origin;

    private void Start()
    {
        origin = transform.position;
    }

    protected override void Update()
    {
        base.Update();

        transform.position = Vector2.Lerp(origin, endPoint, currentCycleTime / cycleRunTime);
    }

    protected override void Reset()
    {
        base.Reset();

        endPoint = transform.position + transform.right * 8;

        cycleType = CycleType.pingpong;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;

        Gizmos.DrawLine(transform.position, endPoint);
    }
}
