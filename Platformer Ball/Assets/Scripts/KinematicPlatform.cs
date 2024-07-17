using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class KinematicPlatform : MonoBehaviour
{
    public float cycleRunTime = 3f;
    public float cycleWaitTime = 1f;
    protected float currentCycleTime = 0;
    protected float currentWaitTime = 0;

    public enum CycleType { repeat, pingpong}
    public CycleType cycleType;

    protected sbyte cycleDirection = 1;

    protected Rigidbody2D rb;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void Reset()
    {
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
    }

    protected virtual void Update()
    {
        if (currentWaitTime <= 0)
        {
            currentCycleTime += Time.deltaTime * cycleDirection;

            HandleCycleEnd();
        }
        else
        {
            currentWaitTime -= Time.deltaTime;

            HandleCycleRestart();
        }
    }

    void HandleCycleRestart()
    {
        if(currentWaitTime < 0)
        {
            currentCycleTime -= currentWaitTime;
            currentWaitTime = 0;
        }
    }

    void HandleCycleEnd()
    {
        switch (cycleType)
        {
            case CycleType.repeat:
                if(currentCycleTime > cycleRunTime)
                {
                    currentWaitTime = cycleWaitTime - (currentCycleTime - cycleRunTime);
                    currentCycleTime = 0;
                }
                break;
            case CycleType.pingpong:
                if(currentCycleTime > cycleRunTime)
                {
                    currentWaitTime = cycleWaitTime - (currentCycleTime - cycleRunTime);
                    cycleDirection = -1;
                    currentCycleTime = cycleRunTime;
                }
                else if (currentCycleTime < 0)
                {
                    currentWaitTime = cycleWaitTime - currentCycleTime;
                    cycleDirection = 1;

                    currentCycleTime = 0;
                }
                break;
        }
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController p = collision.collider.GetComponent<PlayerController>();
        if(p)
        {
            p.transform.SetParent(transform);
        }
    }

    protected virtual void OnCollisionExit2D(Collision2D collision)
    {
        PlayerController p = collision.collider.GetComponent<PlayerController>();
        if (p)
        {
            p.transform.SetParent(null);
        }
    }
}
