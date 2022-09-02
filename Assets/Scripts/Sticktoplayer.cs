using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sticktoplayer : MonoBehaviour
{
    public Transform target;
    public Vector3 Vector3;

    public float smooth = 0.5f;

    private void Start()
    {
        if(!target)
        {
            target = GameObject.Find("Player").transform;
        }
    }

    void LateUpdate()
    {
        transform.position = target.position + Vector3;
    }
}
