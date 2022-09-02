using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class RotateCamera : MonoBehaviour
{
    void FixedUpdate()
    {
        this.transform.Rotate(new Vector3(0, 1, 0), 0.3f);
    }
}
