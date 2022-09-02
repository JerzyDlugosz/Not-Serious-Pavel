using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public AudioManager audioManager;

    void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }
    public void OnClick(int level)
    {
        SceneManager.LoadScene(level);
    }
    public void OnClickWithAudioManager(int level)
    {
        Cursor.visible = false;
        audioManager.ChangeSounds(level);
        SceneManager.LoadScene(level);
    }


}
