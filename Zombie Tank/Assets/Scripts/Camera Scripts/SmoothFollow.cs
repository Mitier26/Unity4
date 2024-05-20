using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
    public Transform target;

    public float distance = 6.3f;
    public float higth = 3.5f;

    public float height_Damping = 3.25f;
    public float rotation_Damping = 0.27f;


    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void LateUpdate()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        float wanted_Rotatioin_Angle = target.eulerAngles.y;
        float wanted_Height = target.position.y + higth;

        float current_Rotation_Angle = transform.eulerAngles.y;
        float current_Height = transform.position.y;

        current_Rotation_Angle = Mathf.LerpAngle(current_Rotation_Angle, wanted_Rotatioin_Angle, rotation_Damping * Time.deltaTime);

        current_Height = Mathf.Lerp(current_Height, wanted_Height, height_Damping * Time.deltaTime);

        Quaternion current_Rotation = Quaternion.Euler(0f, current_Rotation_Angle, 0f);

        transform.position = target.position;
        transform.position -= current_Rotation * Vector3.forward * distance;

        transform.position = new Vector3(transform.position.x, current_Height, transform.position.z); ;
    }
}
