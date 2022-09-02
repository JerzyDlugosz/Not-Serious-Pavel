using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnotherLoadScene : MonoBehaviour
{
    public AudioManager audioManager;
    public int levelNumber;
    private void Start()
    {
        levelNumber = this.GetComponent<LoadGame>().levelNumber;
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        Cursor.visible = false;
        audioManager.ChangeSounds(levelNumber);
        SceneManager.LoadScene(levelNumber);
    }

}
