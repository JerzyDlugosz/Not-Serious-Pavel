using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private GameObject Player;
    private SaveGame save;
    private level level;
    void Start()
    {
        save = GameObject.Find("SaveGameController").GetComponent<SaveGame>();
        Player = GameObject.Find("FPSController");
        Rigidbody rigidbody = Player.GetComponent<Rigidbody>();
        rigidbody.position = gameObject.transform.position;
        Player.transform.localPosition = gameObject.transform.localPosition;
        level = GameObject.Find("Level").GetComponent<level>();
        //save.GameSave(1, level.levelNumber);
    }
}
