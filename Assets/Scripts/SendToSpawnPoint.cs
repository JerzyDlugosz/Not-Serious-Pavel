using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendToSpawnPoint : MonoBehaviour
{
    private Transform spawnPoint;
    private GameObject player;
    void Start()
    {
        spawnPoint = GameObject.Find("SpawnPoint").GetComponent<Transform>();
        player = GameObject.Find("FPSController");
    }

    private void OnTriggerStay(Collider other)
    {
        Rigidbody rigidbody = player.GetComponent<Rigidbody>();
        rigidbody.position = spawnPoint.transform.position;
        player.transform.localPosition = spawnPoint.transform.localPosition;
    }
}
