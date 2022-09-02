using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookat : MonoBehaviour
{
    public GameObject boss;
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("FPSController").transform;
    }

    // Update is called once per frame
    void Update()
    {
        boss.transform.LookAt(player);
    }
}
