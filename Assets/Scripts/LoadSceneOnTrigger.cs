using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneOnTrigger : MonoBehaviour
{
    public int Scene;
    public Text text;
    private int pylonNumber;
    private AudioManager audio;
    private TimeScript time;
    private level level;

    private void Start()
    {
        audio = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        time = GameObject.Find("Timer").GetComponent<TimeScript>();
        level = GameObject.Find("Level").GetComponent<level>();
    }

    private void OnTriggerEnter(Collider other)
    {
        int lvl = 0;
        if (other.tag == "Player")
        {
            pylonNumber = GameObject.FindGameObjectWithTag("Pylon").GetComponent<PylonData>().pylonNumber;
            if (pylonNumber == 0 && time.currentTime == 0)
            {
                if (level.levelNumber == 6)
                {
                    lvl = 2;
                }
                if (level.levelNumber == 11)
                {
                    lvl = 3;
                }
                audio.ChangeSounds(lvl);
                SceneManager.LoadScene(Scene);
            }
            else
            {
                //Debug.Log("NAH");
            }
        }

    }

}
