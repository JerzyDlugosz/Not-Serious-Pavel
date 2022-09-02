using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLoadState : MonoBehaviour
{
    GameObject saveState;
    public void Create(int state)
    {
        saveState = new GameObject("LoadState");
        saveState.AddComponent<LoadState>();
        saveState.GetComponent<LoadState>().secondarySaveFile = state;
        saveState.AddComponent<dontdestroyonload>();
    }
}
