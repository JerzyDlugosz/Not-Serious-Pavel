using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAim : MonoBehaviour
{
    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    public GameObject player;

    public List<Transform> transforms;

    void Update()
    {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");
        if (pitch > 90)
        {
            pitch = 90;
        }
        if (pitch < -90)
        {
            pitch = -90;
        }

        //player.transform.eulerAngles = new Vector3(0, yaw, 0.0f);

        foreach (Transform transform in transforms)
        {
            transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        }
    }
}
