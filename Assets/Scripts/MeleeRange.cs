using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeRange : MonoBehaviour
{

    private CharacterStats stats;
    private void Start()
    {
        stats = this.GetComponentInParent<CharacterStats>();
    }
    private void OnTriggerEnter(Collider other)
    {
        stats.isWithinRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        stats.isWithinRange = false;
    }
}
