using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    public bool alwaysAnimate = false;
    public Vector3 rotationRate = new Vector3(0, 90, 0);
    public AnimationCurve pulseAnimation;
    public AnimationCurve bobAnimation;

    Vector3 originalScale;
    float originHeight;
    Renderer r;

    public virtual void Start()
    {
        r = GetComponent<Renderer>();

        originalScale = transform.localScale;
        originHeight = transform.position.y;
    }

    public virtual void Update()
    {
        if(!alwaysAnimate && r && !r.isVisible)
        {
            return;
        }

        float interval;

        if(rotationRate.sqrMagnitude > 0)
        {
            transform.Rotate(rotationRate * Time.deltaTime);
        }

        if(pulseAnimation.keys.Length > 0)
        {
            interval = pulseAnimation.keys[pulseAnimation.keys.Length - 1].time;

            transform.localScale = originalScale * pulseAnimation.Evaluate((float)(Time.timeAsDouble % interval));

        }

        if (bobAnimation.keys.Length > 0)
        {
            interval = bobAnimation.keys[bobAnimation.keys.Length - 1].time;

            transform.position = new Vector3(transform.position.x, originHeight + bobAnimation.Evaluate((float)(Time.timeAsDouble % interval)), transform.position.z);

        }
    }

    public static int CountNumberInScene()
    {
        return FindObjectsOfType<Pickup>().Length;
    }
}
