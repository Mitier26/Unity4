using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMovingPlatform : KinematicPlatform
{
    public Vector2 center;
    Vector2 origin;
    Vector2 difference;
    float angle;

    private void Start()
    {
        origin = transform.position;
        difference = origin - center;
        angle = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
    }

    protected override void Update()
    {
        base.Update();

        transform.position = center + (Vector2)(Quaternion.Euler(0, 0, angle + 360 * currentCycleTime / cycleRunTime) * difference);
    }

    protected override void Reset()
    {
        base.Reset();

        center = transform.position + transform.right * 8;

        cycleType = CycleType.pingpong;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, center);
        Gizmos.DrawWireSphere(center, ((Vector2)transform.position - center).magnitude);
    }
}
