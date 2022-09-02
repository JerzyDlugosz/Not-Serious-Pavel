using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    private Rigidbody rig;
    private Vector3 NullVel;
    void Start()
    {
        rig = gameObject.GetComponent<Rigidbody>();
        NullVel = rig.velocity;
    }

    void Update()
    {
        
        if (Input.GetKey(KeyCode.W))
        {
            rig.AddForce(transform.forward * 20);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rig.AddForce(-transform.right * 20);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rig.AddForce(-transform.forward * 20);
        }
        if (Input.GetKey(KeyCode.D))
        {    
            rig.AddForce(transform.right * 20);
        }
        if (rig.velocity != NullVel)
        {
            rig.velocity = rig.velocity * 0.95f;
        }
    }
}
