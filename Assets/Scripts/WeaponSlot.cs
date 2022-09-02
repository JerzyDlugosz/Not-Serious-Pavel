using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSlot : MonoBehaviour
{
    public GameObject Object;
    void Start()
    {
        Object.transform.position = gameObject.transform.position;
    }
}
